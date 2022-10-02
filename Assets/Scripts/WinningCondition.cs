using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningCondition : MonoBehaviour
{
    int goblets = 0;

    [SerializeField]
    GameObject confeti;

    bool CanCross;

    SpriteRenderer spriteRenderer;

    PlayerManager Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        CanCross = false;
    }

    private void Update()
    {
        if (CanCross && spriteRenderer.color != Color.yellow) // don't love it but hey, it's a real simple solution
        {
            spriteRenderer.color = Color.yellow; // Now that's real great for perfomance!!!!
        }
    }

    public void CollectedGoblet()
    {
        goblets++;
        float newRadius = 1.9f;
        switch (goblets)
        {
            case 1:
                newRadius = 2.5f;
                break;
            case 2:
                newRadius = 3.1f;
                break;
            case 3:
                newRadius = 3.5f;
                break;
        }
        Player.NewCircleRadius(newRadius);

        if (goblets >= 3)
        {
            CanCross = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!CanCross) return;
        if (other.gameObject.CompareTag("PhysicalPlayer"))
        {
            // you won!!

            Instantiate(confeti, new Vector3(0, 2), Quaternion.identity);

            Invoke("NextLvl", 3);
        }
    }

    void NextLvl()
    {
        ReloadLvl.LoadNextLevel();
    }
}
