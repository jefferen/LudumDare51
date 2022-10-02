using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Missile2 : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float MoveSpeed;

    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * MoveSpeed;
    }
}
