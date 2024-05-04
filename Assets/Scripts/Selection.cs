using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    Vector3 pos;
    [SerializeField] Transform mousePointer;
    [SerializeField] float offset;
    public List<GameObject> selectedItems = new List<GameObject>();

    void Start()
    {
        
    }

    void Update()
    {
        pos = Input.mousePosition;
        pos.z = offset;
        mousePointer.position = Camera.main.ScreenToWorldPoint(pos);
        transform.LookAt(mousePointer);
        if(Input.GetButtonDown("Fire1")) 
        {
            selectedItems.Clear();
            Debug.Log(selectedItems.Count);
        }
        if(Input.GetButton("Fire1")) MouseClicking();
        else if(Input.GetButtonUp("Fire1"))
        {
            for(int i = 0; i < selectedItems.Count; i++)
            {
                selectedItems[i].layer = 0;
                Debug.Log(selectedItems[i].name);
            }
        }
    }

    void MouseClicking()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, 1)) 
        {
            hit.transform.gameObject.layer = 1;
            selectedItems.Add(hit.transform.gameObject);
        }
        Debug.Log(selectedItems.Count);
        Debug.DrawRay(transform.position, transform.forward * 1000, Color.red);
    }
}
