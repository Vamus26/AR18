using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Vuforia;

public class testscript : MonoBehaviour, IVirtualButtonEventHandler
{

    //    public Vuforia.VirtualButton button;
    public GameObject vButton;
    public GameObject vButton2;
    public GameObject vButton3;
    public Discscript disc1;
    public Discscript disc2;
    public Discscript disc3;
    public Polescript polescript1;
    public Polescript polescript2;
    public Polescript polescript3;
    public Discscript selectedDisk = null;
    private RaycastHit hit;
    // Use this for initialization
    void Start()
    {
        polescript1.addBasicElements(disc1, disc2, disc3);
        vButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        vButton2.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        vButton3.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
           // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit_info;
            if (Physics.Raycast(ray, out hit_info))
            {

                if (hit_info.collider.gameObject.name == "Cylinder1")
                {
                    Debug.Log("you hit:" + hit_info.collider.gameObject.name);
                    p1pressed();
                }
                if (hit_info.collider.gameObject.name == "Cylinder2")
                {
                    Debug.Log("you hit:" + hit_info.collider.gameObject.name);
                    p2pressed();
                }
                if (hit_info.collider.gameObject.name == "Cylinder3")
                {
                    Debug.Log("you hit:" + hit_info.collider.gameObject.name);
                    p3pressed();
                }
            }
        }
    }
    public void OnButtonPressed(Vuforia.VirtualButtonBehaviour vb)
    {
        if (vb.name == "vButton")
        {
            p1pressed();

        }
        if (vb.name == "vButton2")
        {
            p2pressed();
        }
        if (vb.name == "vButton3")
        {
            p3pressed();
        }
    }
    public void OnButtonReleased(Vuforia.VirtualButtonBehaviour vb)
    {
    }
    public void p1pressed()
    {
        if (selectedDisk != null)
        {
            Debug.Log("insert p1");
            var success = polescript1.addElement(selectedDisk);
            if (success)
            {
                selectedDisk = null;
            }
        }
        else
        {
            Debug.Log("removed p1");
            selectedDisk = polescript1.getTopDisc();
            polescript1.removeElement();
        }
    }
    public void p2pressed()
    {
        if (selectedDisk != null)
        {
            Debug.Log("insert p2");
            var success = polescript2.addElement(selectedDisk);
            if (success)
            {
                selectedDisk = null;
            }
        }
        else
        {
            Debug.Log("removed p2");
            selectedDisk = polescript2.getTopDisc();
            polescript2.removeElement();
        }
        Debug.Log("2 pressed");
    }
    public void p3pressed()
    {
        if (selectedDisk != null)
        {
            Debug.Log("insert p3");
            var success = polescript3.addElement(selectedDisk);
            if (success)
            {
                selectedDisk = null;
            }
        }
        else
        {
            Debug.Log("removed p3");
            selectedDisk = polescript3.getTopDisc();
            polescript3.removeElement();
        }
        Debug.Log("3pressed");
    }
}
