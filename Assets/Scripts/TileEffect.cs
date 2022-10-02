using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEffect : MonoBehaviour
{
    PlayerManager Player;

    [SerializeField]
    List<Sprite> sprites;

    SpriteRenderer spriteRenderer;

    [SerializeField]
    Color Active, NonActive;

    bool Deadly;

    private void Awake()
    {    
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = NonActive;
        Deadly = false;
    }

    public enum Dice
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        None,
        Hole,
    }

    Dice TileDiceValue;

    public void SetTileDiceValue(int value)
    {
        TileDiceValue = (Dice)value;
        spriteRenderer.sprite = sprites[value - 1];
        if(value == 8) Deadly = true;
        else Deadly = false;
    }

    private void OnMouseOver() // hover and click or hold mouse 0
    {
        if (Deadly) return;
        if(Input.GetMouseButton(0)) Player?.MoveTowardsTarget(transform.position, (int)TileDiceValue);
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
