using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLvl : MonoBehaviour
{
    public static void ReLoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // reloads current scene
    }

    public static void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
