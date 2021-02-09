using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{

    public GameObject objectToSpawn;
    [SerializeField] private Camera camRef;
    private GameObject currSpawnedObject;

	// Use this for initialization
	void Start () {
	    if (camRef == null)
	    {
	        camRef = Camera.main;
	    }
	}

    private void spawnObject(Vector3 place_to_spawn, GameObject object_to_spawn)
    {
        if (currSpawnedObject)
        {
            Destroy(currSpawnedObject);
        }

        currSpawnedObject = Instantiate(object_to_spawn, place_to_spawn, Quaternion.identity);
    }

    

	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        Ray ray = camRef.ScreenPointToRay(new Vector3(camRef.pixelWidth / 2, camRef.pixelHeight / 2, 1.0f));
	        RaycastHit hit_info;
	        if (Physics.Raycast(ray, out hit_info))
	        {
	            spawnObject(hit_info.point, objectToSpawn);            
	        }
	        else
	        {
	            Debug.Log("ray intersected nothing");
	        }
	    }
	}
}
