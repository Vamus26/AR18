using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vbscript2 : MonoBehaviour, IVirtualButtonEventHandler {
    private GameObject vButton;
    private GameObject bigDonut;
    private GameObject midDonut;
    private GameObject smaDonut;
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
    // Use this for initialization
    void Start () {
        vButton = GameObject.Find("vButton2");

        bigDonut = GameObject.Find("bigDonut");
        midDonut = GameObject.Find("midDonut");
        smaDonut = GameObject.Find("smaDonut");
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
            Debug.Log("2 here");
        vButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (smaDonutfloat == true)
        {
            float move = 5.0f * Time.deltaTime;
            smaDonut.transform.localPosition = Vector3.MoveTowards(smaDonut.transform.localPosition, Cy2_float, move);
            smaDonut.transform.rotation = GameObject.Find("Cylinder2").transform.rotation;
            if (Vector3.Distance(smaDonut.transform.localPosition, Cy2_float) < 0.05f)
            {
                smaDonutfloat = false;
                smaDonutlower = true;
            }
        }
        if (smaDonutlower == true)
        {
            float move = 5.0f * Time.deltaTime;
            smaDonut.transform.localPosition = Vector3.MoveTowards(smaDonut.transform.localPosition, Cy2_lower, move);
            smaDonut.transform.rotation = GameObject.Find("Cylinder2").transform.rotation;
            if (Vector3.Distance(smaDonut.transform.localPosition, Cy2_lower) < 0.05f)
            {
                smaDonutlower = false;
            }
        }
        if (smaDonutlow == true)
        {
            float move = 5.0f * Time.deltaTime;
            smaDonut.transform.localPosition = Vector3.MoveTowards(smaDonut.transform.localPosition, Cy2_float, move);
            smaDonut.transform.rotation = GameObject.Find("Cylinder2").transform.rotation;
            if (Vector3.Distance(smaDonut.transform.localPosition, Cy2_float) < 0.05f)
            {
                smaDonutlow = false;
            }
        }
    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if ((Vector3.Distance(smaDonut.transform.localPosition, Cy1_float) < 0.05f) || (Vector3.Distance(smaDonut.transform.localPosition, Cy3_float) < 0.05f)|| (Vector3.Distance(smaDonut.transform.localPosition, Cy2_float) < 0.05f))
        {
            smaDonutfloat = true;
        }
        if ((Vector3.Distance(smaDonut.transform.localPosition, Cy2_lower) < 0.05f))
        {
            smaDonutlow = true;
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("button2 release");
    }
}
