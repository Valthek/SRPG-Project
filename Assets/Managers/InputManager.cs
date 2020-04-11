using System;
using System.Collections;

using Assets.Entities.Interfaces;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    private Transform _selectedUnit;
    private Transform _selectedTile;

    void Start()
    {
        _selectedTile = null;
        _selectedUnit = null;
    }

    void Update()
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                _selectedUnit = SelectObject(hit, _selectedUnit, typeof(IUnit));
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                _selectedTile = SelectObject(hit, _selectedTile, typeof(ITile));
            }
        }
    }

    private Transform SelectObject(RaycastHit hit, Transform gameObjectToSelect, Type targetType)
    {
        if (gameObjectToSelect != null)
        {
            // Deselect current selection
            var selector = gameObjectToSelect.GetComponent(targetType) as ISelectable;
            selector.Deselect();
        }
        if (hit.transform.GetComponent(targetType) != null && hit.transform != gameObjectToSelect)
        {
            var selector = hit.transform.GetComponent(targetType) as ISelectable;
            selector.Select();
            return hit.transform;
        }
        return null;

    }

}
