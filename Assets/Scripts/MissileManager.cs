using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissileManager : MonoBehaviour
{
    [SerializeField]
    List<Transform> missiles;

    [SerializeField]
    GameObject missile;

    float minSpawn, maxSpawn;   

    void Start()
    {
        if ((SceneManager.GetActiveScene().buildIndex + 1) == 5) // some real spicy code, running on fumes
        {
            minSpawn = 1.5f;
            maxSpawn = 6.5f;
        }
        else
        {
            minSpawn = 4.15f;
            maxSpawn = 7.52f;
        }

        Invoke("ShootMissiles", Random.Range(minSpawn, maxSpawn)); // shoot faster at higher lvl's
    }

    void ShootMissiles()
    {
        int indexPos = Random.Range(0, missiles.Count);

        Instantiate(missile, missiles[indexPos].transform.position, Quaternion.identity);
        CancelInvoke();
        Invoke("ShootMissiles", Random.Range(minSpawn, maxSpawn));
    }
}
