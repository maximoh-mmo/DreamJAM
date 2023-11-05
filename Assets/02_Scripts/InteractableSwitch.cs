using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEditor.Experimental.GraphView;

public class InteractableSwitch : MonoBehaviour
{
    Scene scene;
    [SerializeField] float cooldown = 0.5f;
    GameObject toDisable,coconut=null;
    bool isReady = true;
    bool coconutActive=false;
    public void Trigger()
    {
        if (isReady == true)
        {
            StartCoroutine(Cooldown());
        }
    }

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();

        // Check if the name of the current Active Scene is your first Scene.
        if (scene.name == "Beach Level")
        {
            toDisable = GameObject.Find("DisableDuringDay");
            coconut = GameObject.Find("Coconut");
        }

        toDisable.SetActive(false);
   
    }
    private void Update()
    {
        if (coconutActive == true)
        {

        }
    }
    public void doAthingDependingOnMyName()
    {
        Debug.Log("My name is> "+this.gameObject.name);
        if (this.gameObject.name == "LightSwitch")
        {
            if (toDisable.activeSelf == true)
            {
                toDisable.SetActive(false);
            }
            else
            {
                toDisable.SetActive(true);
            }
        }
        else if (this.gameObject.name == "Coconut")
        {
            coconut.GetComponent<Animator>().SetTrigger("fall");
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
