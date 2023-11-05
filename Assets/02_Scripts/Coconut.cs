using System.Collections;
using UnityEngine;

public class Coconut : MonoBehaviour
{
    [SerializeField]Sprite sprite = null;

    public void Fall()
    {
        this.GetComponent<Animator>().enabled = true;
        StartCoroutine(CrabSwap());
    }
    IEnumerator CrabSwap()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        GameObject.Find("Crab").GetComponent<SpriteRenderer>().sprite = sprite;
        GameObject.Find("Crab").GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject);
    }
}
