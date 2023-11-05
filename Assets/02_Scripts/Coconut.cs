using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coconut : MonoBehaviour
{
    bool inTree = true;
    private void Update()
    {
        if (inTree == false)
        {
            Debug.Log("falling");
            if (GetComponent<Animator>().enabled == true && GetComponent<Animation>().isPlaying == false) {

                Debug.Log("squash");
            }
        }
    }
    public void Fall()
    {            
        this.GetComponent<Animator>().enabled = true;
        inTree = false;
    }
}
