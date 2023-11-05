using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableSwitch : MonoBehaviour
{
    [SerializeField] float cooldown = 1f;
    bool isReady = true;
    public void Trigger()
    {
        if (isReady == true)
        {
            StartCoroutine(Cooldown());
        }
    }
    IEnumerator Cooldown() 
    { 
        isReady = false;
        Debug.Log("Triggered");
        yield return new WaitForSeconds(cooldown);
        isReady = true;
        Debug.Log("Ready to be retriggered");
    }
}
