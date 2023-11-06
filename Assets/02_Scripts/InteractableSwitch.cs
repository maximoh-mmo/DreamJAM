using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using JetBrains.Annotations;

public class InteractableSwitch : MonoBehaviour
{
    Scene scene;
    [SerializeField] float cooldown = 0.5f;
    GameObject toDisable,coconut, shovel, tunnel, dice, pivot,butterfly=null;
    bool isReady = true;
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
            shovel = GameObject.Find("Shovel");
            tunnel = GameObject.Find("BlockedTunnel");
        }
        if (scene.name == "CityScene")
        {
            dice = GameObject.Find("Dice");
            pivot = GameObject.Find("pivot");
            butterfly = GameObject.Find("ButterFly");
        }
    }
    private void Start()
    {
        if (scene.name == "Beach Level")
        {
            toDisable.SetActive(false);
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
            coconut.GetComponent<Coconut>().Fall();
        }
        else if (this.gameObject.name == "Shovel")
        {
            Destroy(tunnel);
        }
        else if (this.gameObject.name == "Dice")
        {
            dice.GetComponent<Dice>().RollDice();   
        }
        else if (this.gameObject.name == "pivot")
        {
            pivot.GetComponent<BuildingCollapse>().HulkSmash();
        }
        else if (this.gameObject.name == "ButterFly")
        {
            butterfly.GetComponent<ButterflyWings>().PickUpWings();
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
