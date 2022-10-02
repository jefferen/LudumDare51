using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI ShuffleTime;

    [SerializeField]
    List<TileEffect> effects;

    [SerializeField]
    GameObject goblet;

    [SerializeField]
    int goblets, tileRange;

    [SerializeField]
    GameObject misileManager;

    [SerializeField]
    Material shuffleMat;

    [SerializeField]
    float shuffleSpeed;

    void Start()
    {  
        if (effects.Count == 0) effects.AddRange(transform.GetComponentsInChildren<TileEffect>());
        goblets = 0;
        GetDifficulty();
        InvokeRepeating("ShuffleBoard", 0, 10);
    }

    IEnumerator SetTime()
    {
        int time = 10;

        while (time > 0)
        {
            time--;
            ShuffleTime.text = time.ToString("f0");
            yield return new WaitForSeconds(1);
        }
    }

    public void StopShuffleTime()
    {
        StopAllCoroutines();
        CancelInvoke();
    }

    void GetDifficulty()
    {
        int difficulty = (SceneManager.GetActiveScene().buildIndex + 1);

        switch (difficulty)
        {
            case 1:
                tileRange = 7;
                break;
            case 2:
                tileRange = 8;
                break;
            case 3:
                tileRange = 9;
                break;
            case 4:
                tileRange = 9; 
                misileManager.SetActive(true);
                break;
            case 5:
                tileRange = 9; // we set something else also // add misiles, then after that add more misiles and decrease stare time
                misileManager.SetActive(true);
                break;
        }
    }

    void ShuffleBoard()
    {
        StopAllCoroutines();
        StartCoroutine(SetTime());
        StartCoroutine(ShuffleEffect());

        goblets++;
        if (goblets <= 3)
        {
            Vector2 gobletPos = transform.GetChild(Random.Range(1, effects.Count)).position;
            Instantiate(goblet, new Vector3( gobletPos.x, gobletPos.y, -1), Quaternion.identity);
        }
    }

    IEnumerator ShuffleEffect()
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

        foreach (var item in effects)
        {
            item.SetTileDiceValue(Random.Range(1, tileRange));
        }

        t = 0;

        while (t <= 1)
        {
            t += Time.deltaTime * shuffleSpeed;

            SetShuffle(t, System.Convert.ToBoolean(xOrY));

            yield return null;
        }

        shuffleMat.mainTextureScale = new Vector2(1, 1);
    }

    void SetShuffle(float t, bool x)
    {
        if (x)
        {
            shuffleMat.mainTextureScale = new Vector2(1, t);
        }
        else shuffleMat.mainTextureScale = new Vector2(t, 1);
    }
}
