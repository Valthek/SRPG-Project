using System.Collections;
using Assets.Entities;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    void Update()
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if(hit.transform.GetComponent<IUnit>() != null)
                {
                    hit.transform.GetComponent<IUnit>().Select();
                }
                StartCoroutine(ScaleMe(hit.transform));
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
            }
        }
    }

    IEnumerator ScaleMe(Transform objTr)
    {
        objTr.localScale *= 1.2f;
        yield return new WaitForSeconds(0.5f);
        objTr.localScale /= 1.2f;
    }
}
