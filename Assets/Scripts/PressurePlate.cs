using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool pressed = false;
    public List<GameObject> otherPlates;
    List<GameObject> pressing = new List<GameObject>();
    public int threshold;

    void Start()
    {
        
    }

    void Update()
    {
        if(otherPlates.Count == 0 && pressed) OpenDoor();
        else if(Enough())
        {
            int plateCounter = 0;
            for(int i = 0; i < otherPlates.Count; i++)
            {
                if(otherPlates[i].GetComponent<PressurePlate>().Enough() == true) plateCounter++;
            }
            if(plateCounter == otherPlates.Count) OpenDoor();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        pressing.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        pressing.Remove(other.gameObject);
    }

    public bool Enough()
    {
        return pressing.Count == threshold;
    }

    void OpenDoor()
    {
        Debug.Log("OIEEEEE");
    }
}
