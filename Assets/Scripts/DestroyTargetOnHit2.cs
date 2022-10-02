using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTargetOnHit2 : MonoBehaviour
{
    GameMaster gameMaster;

    private void Awake()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    private void OnCollisionEnter2D(Collision2D other) // on hit effect
    {
       // if (other.gameObject.CompareTag("Player")) Destroy(other.gameObject.transform.parent.gameObject);
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            gameMaster.KillPlayer();
        }
    }
}
