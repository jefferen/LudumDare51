using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField]
    List<TileEffect> effects;
    void Start()
    {
        if (effects.Count == 0) effects.AddRange(transform.GetComponentsInChildren<TileEffect>());
        InvokeRepeating("ShuffleBoard", 0, 10);
    }

    void ShuffleBoard()
    {
        foreach (var item in effects)
        {
            item.SetTileDiceValue(Random.Range(1, 7));
        }
    }

}
