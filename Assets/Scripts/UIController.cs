using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class UIController : MonoBehaviour
{
    [SerializeField] SceneManagement sceneManagement;
    [SerializeField] FailScreen failScreen;
    [SerializeField] WinScreen winScreen;
    [SerializeField] RectTransform Album;
    [SerializeField] TextMeshProUGUI text;
    private void Start()
    {
        if (text != null)
        {
            text.text ="LEVEL "+sceneManagement.index.ToString();
            winScreen.levelTex.text= "LEVEL " + sceneManagement.index.ToString();
            failScreen.levelTex.text= "LEVEL " + sceneManagement.index.ToString();
        } 
    }
    public void Fail()
    {
        failScreen.ShowScreen();
    }
    public void Win()
    {
        winScreen.ShowScreen();
    }
    public void ShowLevels()
    {
        Album.DOScale(Vector3.one, 0.8f).SetEase(Ease.OutBack);
    }
    public void HideLevels()
    {
        Album.DOScale(Vector3.zero, 0.7f).SetEase(Ease.InBack);
    }
    public void RestartScene()
    {
        sceneManagement.RestartScene();
    }
    public void NextLevel()
    {
        sceneManagement.LoadNextLevel();
    }
}
    