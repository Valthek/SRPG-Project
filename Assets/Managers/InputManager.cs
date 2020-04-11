using System.Collections;

using Assets.Entities.Interfaces;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    private Transform selectedUnit;
    private Transform selectedTile;
    void Update()
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (selectedUnit != null)
                {
                    // Deselect current selection
                    selectedUnit.GetComponent<IUnit>().Deselect();
                }
                if (hit.transform.GetComponent<IUnit>() != null)
                {
                    // Set new selection
                    selectedUnit = hit.transform;
                    hit.transform.GetComponent<IUnit>().Select();
                }
                else
                {
                    // If we don't click a unit, deselect the whole thing
                    selectedUnit = null;
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                Debug.Log(hit.transform.name);
                if (selectedTile != null)
                {
                    // Deselect current selection
                    selectedTile.GetComponent<ITile>().Deselect();
                }
                if (hit.transform.GetComponent<ITile>() != null)
                {
                    // Set new selection
                    selectedTile = hit.transform;
                    hit.transform.GetComponent<ITile>().Select();
                }
                else
                {
                    // If we don't click a unit, deselect the whole thing
                    selectedTile = null;
                }
            }
        }
    }

}
