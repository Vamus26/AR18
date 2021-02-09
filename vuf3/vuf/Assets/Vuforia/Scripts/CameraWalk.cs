using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWalk : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private Transform camTrans;

    private float forwardMove = 0.0f;

    private float sidewayMove = 0.0f;


    public void setForward(int forward)
    {
        forwardMove = (float) forward;
    }

    public void setSideways(int sideways)
    {
        sidewayMove = (float) sideways;
    }

	// Use this for initialization
	void Start () {
	    if (camTrans == null)
	    {
	        camTrans = Camera.main.transform;
	    }
	}
	
	// Update is called once per frame
	void Update () {
	    if (forwardMove != 0.0f || sidewayMove != 0.0f)
	    {
	        camTrans.Translate(new Vector3(sidewayMove * moveSpeed * Time.deltaTime, 0.0f, forwardMove * moveSpeed * Time.deltaTime), Space.Self);
	    }
	}
}
