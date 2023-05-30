using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using System.Drawing;

public class LimitlessController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScore;
    [SerializeField] TextMeshProUGUI currentScore;
    public static Action onScoreUp;
    private void Start()
    {
        onScoreUp += () => {
            highScore.text = PlayerPrefs.GetInt("HIGH", 0).ToString();
            currentScore.text =InputManager.instance.Level.ToString();
        };
        highScore.text = "HIGH: "+PlayerPrefs.GetInt("HIGH", 0).ToString();
        currentScore.text = "YOUR: "+"0";
    }
}
