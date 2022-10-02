using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayLevelNumber : MonoBehaviour
{
    TMPro.TextMeshProUGUI lvlNumber;

    private void Awake()
    {
        lvlNumber = GetComponent<TMPro.TextMeshProUGUI>();
        lvlNumber.text = (SceneManager.GetActiveScene().buildIndex + 1).ToString();
    }
}
