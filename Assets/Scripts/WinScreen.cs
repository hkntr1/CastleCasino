using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
public class WinScreen : MonoBehaviour
{
    RectTransform rectTransform;
    public TextMeshProUGUI levelTex;
    [SerializeField] Image background;
    [SerializeField] RectTransform buttons, againOrSkip, levelText;
    [Header("Poses")]
    [SerializeField] Vector3 buttonsPos, againOrSkipPos, levelTextPos;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void ShowScreen()
    {
        gameObject.SetActive(true);
        background.DOColor(Color.white, 1f);
        buttons.DOMoveY(225f, 1f).SetEase(Ease.InOutBack);
        againOrSkip.DOMoveX(Screen.width/2, 1f).SetEase(Ease.InOutBack);
        levelText.DOMoveY(Screen.height-200f, 1f).SetEase(Ease.InOutBack);
    }
}

