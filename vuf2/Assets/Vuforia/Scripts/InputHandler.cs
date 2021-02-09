using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    [SerializeField] private CameraWalk camWalkRef;

	// Use this for initialization
	void Start () {
	    if (camWalkRef == null)
	    {
	        camWalkRef = Camera.main.GetComponent<CameraWalk>();
	        if (camWalkRef == null)
	        {
	            camWalkRef = Camera.main.gameObject.AddComponent<CameraWalk>();
	        }
	    }
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.W))
	    {
	        camWalkRef.setForward(1);
	    }
        else if (Input.GetKey(KeyCode.S))
	    {
	        camWalkRef.setForward(-1);
	    }
	    else
	    {
	        camWalkRef.setForward(0);
	    }

        if (Input.GetKey(KeyCode.A))
	    {
	        camWalkRef.setSideways(-1);
	    }
	    else if (Input.GetKey(KeyCode.D))
	    {
	        camWalkRef.setSideways(1);
	    }
        else
        {
            camWalkRef.setSideways(0);
        }

    }
}
