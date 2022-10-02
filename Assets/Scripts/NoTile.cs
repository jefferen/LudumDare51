using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoTile : MonoBehaviour
{
    PlayerManager Player;

    SpriteRenderer spriteRenderer;

    [SerializeField]
    Color Active, NonActive;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = NonActive;
    }
    private void OnMouseOver() // hover and click or hold mouse 0
    {
        if (Input.GetMouseButton(0)) Player?.MoveTowardsTarget(transform.position,0);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        spriteRenderer.color = Active;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        spriteRenderer.color = NonActive;
    }
}
