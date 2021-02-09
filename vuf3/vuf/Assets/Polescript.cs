using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Polescript : MonoBehaviour
{
    public List<Discscript> discs = new List<Discscript>();

    public bool isEmpty()
    {
        return discs.Count == 0;
    }
    public bool addElement(Discscript disc)
    {
        if (checkElement(disc))
        {
            disc.moveToPole(this);
            discs.Add(disc);
            return true;
        }
        return false;
    }

    public bool checkElement(Discscript disc)
    {
        if (disc == null)
        {
            return false;
        }
        if (discs.Count == 0)
        {
            return true;
        }
        return disc.Number < getTopDisc().Number;
    }
    public void removeElement()
    {
        if (discs.Count != 0)
        {
   //         discs[discs.Count - 1].FFdestination = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 0.5f, this.transform.localPosition.z);
   //         discs[discs.Count - 1].upwego = true;
           discs[discs.Count - 1].transform.Translate(0.0f, 1.0f, 0.0f);
            discs.RemoveAt(this.discs.Count - 1);
        }
    }

    public Discscript getTopDisc()
    {
        if(discs.Count > 0)
        {
            return discs[discs.Count - 1];
        }
        return null;
    }

    internal void addBasicElements(Discscript disc1, Discscript disc2, Discscript disc3)
    {
        discs.Add(disc1);
        discs.Add(disc2);
        discs.Add(disc3);
    }
}