using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI DemandedDiceValueText;

    [SerializeField]
    PlayerManager player;

    SpriteRenderer spriteRenderer;

    int DemandedDiceValue;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.green;
        SetDemandedDiceValue();
        Invoke("DeathStare", 5f); // maybe change to higher value, for testing we have low value
    }

    IEnumerator DeathStare2()
    {
        CancelInvoke();
        spriteRenderer.color = Color.red;
        float t = 0;
        float StareTime = Random.Range(2.25f, 2.75f);

        while (t <= StareTime)
        {
            t += Time.deltaTime;
            if (player.StandingTileValue != DemandedDiceValue) KillPlayer();
            yield return null;
        }
        spriteRenderer.color = Color.green;

        float NextDiceValueTime = Random.Range(2.2f, 7.5f);
        float NextDeathStareTime = Random.Range(3.6f, 7.5f) + NextDiceValueTime;

        Invoke("SetDemandedDiceValue", NextDiceValueTime);
        Invoke("DeathStare", NextDeathStareTime);
    }

    void DeathStare()
    {
        StartCoroutine(DeathStare2());  
    }

    void KillPlayer() // shot player and show death title
    {
        ReloadLvl.ReLoadLevel();
    }

    void SetDemandedDiceValue()
    {
        DemandedDiceValue = Random.Range(1, 7);
        DemandedDiceValueText.text = DemandedDiceValue.ToString();
    }
}
