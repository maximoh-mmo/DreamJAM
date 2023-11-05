using System.Collections;
using UnityEngine;

public class InteractableSwitch : MonoBehaviour
{
    [SerializeField] float cooldown = 1f;
    GameObject toDisable=null;
    bool isReady = true;
    public void Trigger()
    {
        if (isReady == true)
        {
            StartCoroutine(Cooldown());
        }
    }

    public void doAthingDependingOnMyName()
    {
        Debug.Log("My name is> "+this.gameObject.name);
        if (this.gameObject.name == "LightSwitch") {
            if (toDisable == null) { toDisable = GameObject.Find("DisableDuringDay"); }
            if (toDisable.activeSelf == true)
            {
                toDisable.SetActive(false);
            }
            else
            {
                toDisable.SetActive(true);
            }
        }
    }
    IEnumerator Cooldown() 
    { 
        isReady = false;
        doAthingDependingOnMyName();
        yield return new WaitForSeconds(cooldown);
        isReady = true;
        Debug.Log("Ready to be retriggered");
    }
}
