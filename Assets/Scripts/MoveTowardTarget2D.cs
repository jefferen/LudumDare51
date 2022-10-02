using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveTowardTarget2D : MonoBehaviour
{
    PlayerManager Player;

    Rigidbody2D rb;

    [SerializeField]
    float MoveSpeed;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (Player.transform.position - transform.position).normalized * MoveSpeed;
    }
}
