using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    public UnityEvent OnEndScreen;

    [SerializeField]
    TMPro.TextMeshProUGUI scoreText, currentScoreGoal, highScore;

    int scoreValue, highScoreValue;

    void Start()
    {
        highScoreValue = PlayerPrefs.GetInt("HighScore");
        scoreText = GetComponent<TMPro.TextMeshProUGUI>();
        StartCoroutine(AddTimeScore());
    }

    IEnumerator AddTimeScore()
    {
        while (true)
        {
            scoreValue++;
            scoreText.text = scoreValue.ToString();
            yield return new WaitForSeconds(1);
        }
    }

    public void GameEnd()
    {
        StopAllCoroutines();
        if(scoreValue > highScoreValue)
        {
            highScoreValue = scoreValue; // celebrate
            PlayerPrefs.SetInt("HighScore", highScoreValue);
            PlayerPrefs.Save();
        }
        ShowEndScore();
    }

    void ShowEndScore()
    {
        OnEndScreen?.Invoke();
        currentScoreGoal.text = scoreValue.ToString();
        highScore.text = highScoreValue.ToString();
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
