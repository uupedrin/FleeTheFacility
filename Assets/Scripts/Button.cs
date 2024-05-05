using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool pressed = false;
    public List<GameObject> otherButtons;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(otherButtons.Count == 0 && pressed) OpenDoor();
        else if(pressed)
        {
            int buttonCounter = 0;
            for(int i = 0; i < otherButtons.Count; i++)
            {
                if(otherButtons[i].GetComponent<Button>().pressed == true) buttonCounter++;
            }
            if(buttonCounter == otherButtons.Count) OpenDoor();
        }
    }

    void OnTriggerStay(Collider other)
    {
        pressed = true;
    }

    void OnTriggerExit(Collider other)
    {
        pressed = false;
    }

    void OpenDoor()
    {

    }
}
