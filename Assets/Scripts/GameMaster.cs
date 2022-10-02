using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TileEffect;
using static UnityEngine.Rendering.DebugUI;

public class GameMaster : MonoBehaviour
{
    PlayerManager Player;

    [SerializeField]
    List<Sprite> sprites;

    [SerializeField]
    SpriteRenderer dice;

    int DemandedDiceValue;

    [SerializeField]
    Vector2 NextDiceValueTime, NextDeathStareTime; // 2.2 - 7.1    // 3.6 - 7.5

    [SerializeField]
    GameObject gameOverScreen;

    [SerializeField]
    ScoreManager scoreManager;

    [SerializeField]
    BoardManager boardManager;

    [SerializeField]
    CameraShakeCinemachine shakeCinemachine;

    [SerializeField]
    Animator animator;

    bool StaringAtPlayer;

    [SerializeField]
    GameObject Laser;

    [SerializeField]
    Material BigDice;

    [SerializeField]
    float shuffleSpeed;

    [SerializeField]
    AudioClip DeathStareAudio;

    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        SetDemandedDiceValue();
        Invoke("AnimDeathStare", 5f); // maybe change to higher value, for testing we have low value
    }

    IEnumerator StaringAtPlayerWithDeathStare()
    {
        CancelInvoke();

        while (StaringAtPlayer)
        {
            audioSource.PlayOneShot(DeathStareAudio);
            if (Player.StandingTileValue != DemandedDiceValue) DeathShoot();
            yield return null;
        }

        float NextDiceValueTimeNow = Random.Range(NextDiceValueTime.x, NextDiceValueTime.y);
        float NextDeathStareTimeNow = Random.Range(NextDeathStareTime.x, NextDeathStareTime.y) + NextDiceValueTimeNow; // these two values should be changed over time to increase the dificulty

        animator.SetBool("DeathStare", false);

        Invoke("SetDemandedDiceValue", NextDiceValueTimeNow);
        Invoke("AnimDeathStare", NextDeathStareTimeNow);
    }

    void AnimDeathStare()
    {
        animator.SetBool("DeathStare", true);
    }
    public void DeathStare()
    {
        StaringAtPlayer = true; // this animator thingy is really good....... I want to call the anim then do anim how hard is that
        StartCoroutine(StaringAtPlayerWithDeathStare());
    }

    public void StopDeathStare()
    {
        StaringAtPlayer = false;
    }

    public void KillPlayer() // shot player and show death title
    {
        audioSource.Play();
        StopAllCoroutines();
        CancelInvoke();

        animator.SetBool("DeathStare", false);

        shakeCinemachine.Shake();

        boardManager.StopShuffleTime();

        StartCoroutine(ShowEndScreen());
    }

    void DeathShoot()
    {
        KillPlayer();
        Instantiate(Laser, transform.position, Quaternion.identity);
    }

    IEnumerator ShowEndScreen()
    {
        yield return new WaitForSeconds(1.5f);
        gameOverScreen.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(2.7f);
        scoreManager.GameEnd();
    }

    void SetDemandedDiceValue()
    {
        StartCoroutine(ShuffleEffect());
    }

    IEnumerator ShuffleEffect() // i know i know, duplicated code
    {
        float t = 1;
        int xOrY = Random.Range(0, 2);

        while (t < 0)
        {
            t -= Time.deltaTime * shuffleSpeed;

            SetShuffle(t, System.Convert.ToBoolean(xOrY));

            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        DemandedDiceValue = Random.Range(1, 7);
        dice.sprite = sprites[DemandedDiceValue - 1];

        t = 0;
        xOrY = Random.Range(0, 2);

        while (t <= 1)
        {
            t += Time.deltaTime * shuffleSpeed;

            SetShuffle(t, System.Convert.ToBoolean(xOrY));

            yield return null;
        }

        BigDice.mainTextureScale = new Vector2(1, 1);
    }

    void SetShuffle(float t, bool x)
    {
        if (x)
        {
            BigDice.mainTextureScale = new Vector2(1, t);
        }
        else BigDice.mainTextureScale = new Vector2(t, 1);
    }

    public void ReloadLevel()
    {
        ReloadLvl.ReLoadLevel();
    }
}
