using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Dice : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sprite = null;
    int spr = 0;
    private void Start()
    {
        spriteRenderer = GameObject.Find("SpeechBubbles").GetComponent<SpriteRenderer>();
    }

    public void RollDice() { 
        switch (spr)
        {
            case 0:
                spr = 1;
                break;
            case 1:
                spr = 2;
                break;
            case 2:
                spr = 1;
                break;
            default:
                spr = 0;
                break;
        }
        spriteRenderer.sprite = sprite[spr];
        if (spr == 2)
        {
            GameObject.Find("Group1").GetComponent<PolygonCollider2D>().enabled = true;
            GameObject.Find("Character").GetComponent<CharacterControllerScript>().JumpModifier = 10f;

            GameObject.Find("Character").GetComponent<SpriteRenderer>().material.color = new Color(GameObject.Find("Character").GetComponent<SpriteRenderer>().material.color.r, GameObject.Find("Character").GetComponent<SpriteRenderer>().material.color.g, GameObject.Find("Character").GetComponent<SpriteRenderer>().material.color.b, 1f);
            //20 high jump
        }
        if (spr == 1) {
            GameObject.Find("Character").GetComponent<CharacterControllerScript>().JumpModifier = 6f;
            GameObject.Find("Character").GetComponent<SpriteRenderer>().material.color = new Color(GameObject.Find("Character").GetComponent<SpriteRenderer>().material.color.r, GameObject.Find("Character").GetComponent<SpriteRenderer>().material.color.g, GameObject.Find("Character").GetComponent<SpriteRenderer>().material.color.b, 0.4f);
            GameObject.Find("Group1").GetComponent<PolygonCollider2D>().enabled = false;
            //ghost
        }
    }
}
