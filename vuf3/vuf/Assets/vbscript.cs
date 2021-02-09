using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vbscript : MonoBehaviour, IVirtualButtonEventHandler {
    private GameObject vButton;
    private GameObject bigDonut;
    private GameObject midDonut;
    private GameObject smaDonut;
    private Vector3 originalSmaLoction;
    private Quaternion originalSmaRotation;
    private Vector3 Cy3_position;
    private Vector3 Cy3_float;
    private Vector3 Cy2_position;
    private Vector3 Cy2_float;
    private Vector3 Cy3_lower;
    private Vector3 Cy2_lower;
    private Vector3 Cy1_lower;
    private Vector3 Cy1_position;
    private Vector3 Cy1_float;
    private bool smaDonutfloat = false;
    private bool smaDonutlower = false;
    private bool smaDonutlow = false;
    private bool click1 = false;
    // Use this for initialization
    void Start () {
        vButton = GameObject.Find("vButton");

        bigDonut = GameObject.Find("bigDonut");
        midDonut = GameObject.Find("midDonut");
        smaDonut = GameObject.Find("smaDonut");
        originalSmaLoction = smaDonut.transform.position;
        originalSmaRotation = smaDonut.transform.rotation;

        Cy3_position = GameObject.Find("Cylinder3").transform.localPosition;
        Cy3_float.x = Cy3_position.x;
        Cy3_float.y = 0.75f;
        Cy3_float.z = Cy3_position.z;

        Cy3_lower.x = Cy3_float.x;
        Cy3_lower.y = Cy3_float.y - 0.75f;
        Cy3_lower.z = Cy3_float.z;

        Cy1_position = GameObject.Find("Cylinder1").transform.localPosition;
        Cy1_float.x = Cy1_position.x;
        Cy1_float.y = 0.75f;
        Cy1_float.z = Cy1_position.z;

        Cy1_lower.x = Cy1_float.x;
        Cy1_lower.y = Cy1_float.y - 0.75f;
        Cy1_lower.z = Cy1_float.z;

        Cy2_position = GameObject.Find("Cylinder2").transform.localPosition;
        Cy2_float.x = Cy2_position.x;
        Cy2_float.y = 0.75f;
        Cy2_float.z = Cy2_position.z;

        Cy2_lower.x = Cy2_float.x;
        Cy2_lower.y = Cy2_float.y - 0.75f;
        Cy2_lower.z = Cy2_float.z;


        if (vButton != null)
        {
            Debug.Log(Cy1_position);
            Debug.Log(Cy1_float);
        }
        vButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }
	
	// Update is called once per frame
	void Update () {
        if (click1)
        {
            float move = 5.0f * Time.deltaTime;
            smaDonut.transform.localPosition = Vector3.MoveTowards(smaDonut.transform.localPosition, Cy1_float, move);
            smaDonut.transform.rotation = GameObject.Find("Cylinder3").transform.rotation;
            if (Vector3.Distance(smaDonut.transform.localPosition, Cy1_float) < 0.05f)
            {
                click1 = false;
            }
        }
        if (smaDonutfloat == true)
        {
            float move = 5.0f * Time.deltaTime;
            smaDonut.transform.localPosition = Vector3.MoveTowards(smaDonut.transform.localPosition, Cy1_float, move);
            smaDonut.transform.rotation = GameObject.Find("Cylinder1").transform.rotation;
            if (Vector3.Distance(smaDonut.transform.localPosition, Cy1_float) < 0.05f)
            {
                smaDonutfloat = false;
                smaDonutlower = true;
            }
        }
        if (smaDonutlower == true)
        {
            float move = 5.0f * Time.deltaTime;
            smaDonut.transform.localPosition = Vector3.MoveTowards(smaDonut.transform.localPosition, Cy1_lower, move);
            smaDonut.transform.rotation = GameObject.Find("Cylinder1").transform.rotation;
            if (Vector3.Distance(smaDonut.transform.localPosition, Cy1_lower) < 0.05f)
            {
                smaDonutlower = false;
            }
        }
    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if ((Vector3.Distance(smaDonut.transform.localPosition, Cy1_float) < 0.05f) || (Vector3.Distance(smaDonut.transform.localPosition, Cy3_float) < 0.05f) || (Vector3.Distance(smaDonut.transform.localPosition, Cy2_float) < 0.05f))
        {
            smaDonutfloat = true;
        }
        if ((Vector3.Distance(smaDonut.transform.localPosition, Cy1_lower) < 0.05f))
        {
            smaDonutlow = true;
        }
        click1 = true;
  /*      if (smaDonut.transform.position == originalSmaLoction && smaDonut.transform.rotation == originalSmaRotation)
        {
            Debug.Log("part1");
            smaDonut.transform.Translate(0.0f, 0.5f, 0.0f);
        }
        else
        {
            smaDonut.transform.position = GameObject.Find("Cylinder1").transform.position;
            smaDonut.transform.Translate(0.0f, 0.5f, 0.0f);
            smaDonut.transform.rotation = GameObject.Find("Cylinder1").transform.rotation;*/
            //         smaDonut.transform.position = originalSmaLoction;
            //       smaDonut.transform.rotation = originalSmaRotation;
    //    }
       // smaDonut.transform.position = GameObject.Find("Cylinder1").transform.position;
       // float tmpy = smaDonut.transform.position.y+0.5f;
      //  smaDonut.transform.position.y = tmpy;
      //  smaDonut.transform.rotation = GameObject.Find("Cylinder1").transform.rotation;
        Debug.Log("button1");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
    //    Debug.Log("testl release");
    }
}
