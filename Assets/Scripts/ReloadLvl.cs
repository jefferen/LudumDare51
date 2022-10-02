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

    public static void LoadNextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex > SceneManager.sceneCount - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
