using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    public int StandingTileValue;

    [SerializeField]
    List<Sprite> sprites;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    float moveSpeed;

    bool isMoving = false;

    CircleCollider2D collider;

    private void Start()
    {
        gameObject.layer = 2;
        collider = GetComponent<CircleCollider2D>();    
    }

    public void MoveTowardsTarget(Transform target, int tileDiceValue)
    {
        if (!isMoving && Vector2.Distance(target.position, transform.position) < collider.radius + 0.5f) StartCoroutine(MovingToTarget(target, tileDiceValue));
    }

    IEnumerator MovingToTarget(Transform targetPos, int tileDiceValue)
    {
        isMoving = true;
        float t = 0;
        Vector2 startPos = transform.position;

        while (t <= 1)
        {
            t += Time.deltaTime * moveSpeed;
            transform.position = Vector2.Lerp(startPos, targetPos.position, t);
            yield return null;
        }

        transform.position = targetPos.position; // for safe measure
        isMoving = false;
        StandingTileValue = tileDiceValue;
        spriteRenderer.sprite = sprites[StandingTileValue - 1];

    }
}
