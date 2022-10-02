using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblet : MonoBehaviour
{
    WinningCondition winningCondition;

    private void Awake()
    {
        winningCondition = GameObject.FindGameObjectWithTag("Goal").GetComponent<WinningCondition>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            winningCondition.CollectedGoblet();
            Destroy(gameObject);
        }
    }
}
