using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vbscript3 : MonoBehaviour, IVirtualButtonEventHandler {
    private GameObject vButton;
    private GameObject bigDonut;
    private GameObject midDonut;
    private GameObject smaDonut;
    private GameObject cylinder;
    bool clicked = false;
    private Vector3 Cy3_position;
    private Vector3 Cy3_float;
    private Vector3 Cy2_position;
    private Vector3 Cy2_float;
    private Vector3 Cy3_lower;
    private Vector3 Cy1_position;
    private Vector3 Cy1_float;
    private bool smaDonutfloat = false;
    private bool smaDonutlower = false;
    private bool smaDonutlow = false;
    // Use this for initialization
    void Start () {
        vButton = GameObject.Find("vButton3");
     //   cylinder = GameObject.Find("Cylinder3");
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

        Cy2_position = GameObject.Find("Cylinder2").transform.localPosition;
        Cy2_float.x = Cy2_position.x;
        Cy2_float.y = 0.75f;
        Cy2_float.z = Cy2_position.z;
        //position.y = position.y + 0.5f;

        bigDonut = GameObject.Find("bigDonut");
        midDonut = GameObject.Find("midDonut");
        smaDonut = GameObject.Find("smaDonut");

        if (vButton != null)
            Debug.Log("3 here");
        vButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }
	
	// Update is called once per frame
	void Update () {
        if(smaDonutfloat == true){
            float move = 5.0f * Time.deltaTime;
            smaDonut.transform.localPosition = Vector3.MoveTowards(smaDonut.transform.localPosition, Cy3_float, move);
            smaDonut.transform.rotation = GameObject.Find("Cylinder3").transform.rotation;
            if (Vector3.Distance(smaDonut.transform.localPosition, Cy3_float) < 0.05f)
            {
                smaDonutfloat = false;
                smaDonutlower = true;
            }
        }
        if(smaDonutlower == true)
        {
            float move = 5.0f * Time.deltaTime;
            smaDonut.transform.localPosition = Vector3.MoveTowards(smaDonut.transform.localPosition, Cy3_lower, move);
            smaDonut.transform.rotation = GameObject.Find("Cylinder3").transform.rotation;
            if (Vector3.Distance(smaDonut.transform.localPosition, Cy3_lower) < 0.05f)
            {
                smaDonutlower = false;
            }
        }
        if (smaDonutlow == true)
        {
            float move = 5.0f * Time.deltaTime;
            smaDonut.transform.localPosition = Vector3.MoveTowards(smaDonut.transform.localPosition, Cy3_float, move);
            smaDonut.transform.rotation = GameObject.Find("Cylinder3").transform.rotation;
            if (Vector3.Distance(smaDonut.transform.localPosition, Cy3_float) < 0.05f)
            {
                smaDonutlow = false;
            }
        }

    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if ((Vector3.Distance(smaDonut.transform.localPosition, Cy1_float) < 0.05f) || (Vector3.Distance(smaDonut.transform.localPosition, Cy3_float) < 0.05f) || (Vector3.Distance(smaDonut.transform.localPosition, Cy2_float) < 0.05f))
        {
            smaDonutfloat = true;
        }
        if ((Vector3.Distance(smaDonut.transform.localPosition, Cy3_lower) < 0.05f))
        {
            smaDonutlow = true;
        }
       // if ((smaDonut.transform.position == Cy3_position/*GameObject.Find("Cylinder3").transform.position*/) && (smaDonut.transform.rotation == GameObject.Find("Cylinder3").transform.rotation))
      //  {
      //      smaDonut.transform.Translate(0.0f, 1.5f, 0.0f);
     //   }
     //   else
      //  {
      //      clicked = true;
          //  clicked = true;
         //   StartCoroutine(Example());
            //   float move = 20.0f * Time.deltaTime;
            // smaDonut.transform.position = Vector3.MoveTowards(smaDonut.transform.position, GameObject.Find("Cylinder3").transform.position, move);
            //  //smaDonut.transform.position = GameObject.Find("Cylinder3").transform.position;
       //     clicked = false;
       //     smaDonut.transform.rotation = GameObject.Find("Cylinder3").transform.rotation;
    //    }
        //smaDonut.transform.SetPositionAndRotation(position, GameObject.Find("Cylinder3").transform.rotation);//= position;

    }
    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("button3 release");
    }
}
