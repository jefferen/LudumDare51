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

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameObject.layer = 2;
        collider = GetComponent<CircleCollider2D>();
        spriteRenderer.sprite = null;
        StandingTileValue = 7;
    }
    public void MoveTowardsTarget(Vector2 target, int tileDiceValue)
    {
        if (!isMoving && Vector2.Distance(target, transform.position) < collider.radius + 0.5f) StartCoroutine(MovingToTarget(target, tileDiceValue));
    }

    IEnumerator MovingToTarget(Vector2 targetPos, int tileDiceValue = 0)
    {
        audioSource.Play();
        isMoving = true;
        float t = 0;
        Vector2 startPos = transform.position;

        while (t <= 1)
        {
            t += Time.deltaTime * moveSpeed;
            transform.position = Vector2.Lerp(startPos, targetPos, t);
            yield return null;
        }

        transform.position = targetPos; // for safe measure
        isMoving = false;

        if(tileDiceValue >= 1 && tileDiceValue <= 6) StandingTileValue = tileDiceValue;
        spriteRenderer.sprite = sprites[StandingTileValue - 1];
    }

    public void NewCircleRadius(float newRadius)
    {
        collider.radius = newRadius;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
        CancelInvoke();
    }
}
