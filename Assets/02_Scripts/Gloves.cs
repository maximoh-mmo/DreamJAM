using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Gloves : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GameObject.Find("Character").GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Character")
        {
            GameObject.Find("Character").GetComponent<SpriteRenderer>().material.color = new Color(.2f, 1f, .2f, 1f);
            GameObject.Find("Character").GetComponent<CharacterControllerScript>().JumpModifier = 6f;
            GetComponent<BuildingCollapse>().HulkMode = true;
        }
    }
}
