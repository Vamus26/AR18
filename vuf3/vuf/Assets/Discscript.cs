using System;
using UnityEngine;

public class Discscript : MonoBehaviour
{
    public int Number;
    public Vector3 destination;
    public Vector3 Fdestination;
    public bool floatSwitch = false;
    public bool lowerSwitch = false;
    public bool arrived = false;
    public int numberOfDiscs;
    public bool onceswitch = false;
//    public bool upwego = false;
 //   public Vector3 FFdestination;
    
    public void Update()
    {
        if (floatSwitch == true)
        {
            if (Fdestination != this.transform.localPosition)
            {
                moveIt();
            }
            if(Fdestination == this.transform.localPosition)
            {
                floatSwitch = false;
                lowerSwitch = true;
                onceswitch = true;
            }
        }
        if (lowerSwitch == true)
        {
            if (destination != this.transform.localPosition)
            {
                if (onceswitch == true)
                {
                    if (numberOfDiscs == 0)
                    {
                        destination = new Vector3(destination.x, destination.y + 0.05f, destination.z);
                    }
                    if (numberOfDiscs == 1)
                    {
                        destination = new Vector3(destination.x, destination.y + 0.15f, destination.z);
                    }
                    if (numberOfDiscs == 2)
                    {
                        destination = new Vector3(destination.x, destination.y + 0.25f, destination.z);
                    }
                    onceswitch = false;
                }
                moveItDown();
            }
            if (destination == this.transform.localPosition)
            {
                lowerSwitch = false;
            }
        }
    /*    if (upwego == true)
        {
            if (FFdestination != this.transform.localPosition)
            {
                moveItUp();
            }
            if (FFdestination == this.transform.localPosition)
            {
                upwego = false;
            }*
        }*/
    }
    public void moveToPole(Polescript destinationPole)
    {
        Debug.Log("movetopole");
        numberOfDiscs = destinationPole.discs.Count;
        destination = destinationPole.transform.localPosition;
        Fdestination = new Vector3(destination.x, destination.y + 0.5f, destination.z);
        floatSwitch = true;
        this.transform.rotation = destinationPole.transform.rotation;
    }
    public void moveIt()
    {
        float move = 1.0f * Time.deltaTime;
        this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, Fdestination, move);
    }
    public void moveItDown()
    {
        float move = 1.0f * Time.deltaTime;
        this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, destination, move);
    }

  /*  public void moveItUp()
    {
        float move = 1.0f * Time.deltaTime;
        this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, FFdestination, move);
    }*/

}