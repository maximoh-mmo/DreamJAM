using System.Collections;
using UnityEngine;

public class ButterflyWings : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GameObject.Find("Character").GetComponent<SpriteRenderer>();
    }
    public void PickUpWings()
    {
        Debug.Log("triggered wings");
        GameObject.Find("Character").transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        GameObject.Find("Character").GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
        transform.SetParent(GameObject.Find("WingConnection").transform);
        transform.position = transform.parent.position;
        transform.rotation = transform.parent.rotation;
        //GetComponent<Animator>().enabled = true;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Bullies")
        {
            GameObject.Find("Bully1").GetComponent<Animator>().enabled = true;
            GameObject.Find("Bully2").GetComponent<Animator>().enabled = true;
            GameObject.Find("Bully3").GetComponent<Animator>().enabled = true;
            Destroy(GameObject.Find("Speech_Bubble_4"));
            StartCoroutine(waitToDestroy());
        }
    }
    private IEnumerator waitToDestroy()
    {
        yield return new WaitForSeconds(.25f);
        Destroy(GameObject.Find("Bullies"));
        Destroy(this.gameObject);
    }
}
