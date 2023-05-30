using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    SceneManager sceneManager;
    
    public int index;
    void Start()
    {
        index=SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("level", index);

    }
    public void RestartScene()
    {
        SceneManager.LoadScene(index);
    }
    public void LoadNewLevel(int index)
        {
        SceneManager.LoadScene(index);
        }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(index+1);
    }
}
