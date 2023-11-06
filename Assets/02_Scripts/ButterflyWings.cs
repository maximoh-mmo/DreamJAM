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
    }
}
