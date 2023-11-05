using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coconut : MonoBehaviour
{
    bool inTree = true;
    [SerializeField]Sprite sprite = null;

    public void Fall()
    {
        this.GetComponent<Animator>().enabled = true;
        inTree = false;
        StartCoroutine(CrabSwap());
    }
    IEnumerator CrabSwap()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("Crab").GetComponent<SpriteRenderer>().sprite = sprite;
        GameObject.Find("Crab").GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject);
    }
}
