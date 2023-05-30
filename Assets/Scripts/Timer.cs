using TMPro;
using UnityEngine;
using DG.Tweening;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    public float firstTime = 10;
    private float timer;
    public bool canCount;
    public static Action countDown;
    public static Action onCountComplate;
    private void Start()
    {
        countDown += () =>
        {
            timeText.gameObject.SetActive(true);
            timer = firstTime;
            canCount= true;
        };
        onCountComplate += () => {
           
            timeText.gameObject.SetActive(false);
            canCount= false;       
            if (InputManager.instance.currentBomb.gameObject == null)
            {
                StateManager.instance.UpdateGameState(StateManager.GameState.Fail);
            }
            else
            {
                InputManager.instance.currentBomb.knockBack();
            }
        };
        timer = firstTime;
    }
    void Update()
    {
        if (canCount)
        {
            int counter = (int)timer;
            timer -= Time.deltaTime;
            timeText.transform.localScale = Vector3.one + Vector3.one * Mathf.Sin(Time.time * 2f) * 0.1f;

            if (counter != (int)timer)
            {

                timeText.transform.DOScale(Vector3.one * 1.2f, 0.5f).SetEase(Ease.OutBack).OnComplete(() => { timeText.transform.DOScale(Vector3.one, 0.5f); });
            }
            timeText.text = ((int)timer).ToString();
            if ((int)timer==0)
            {
                onCountComplate?.Invoke();
            }
        }
    }
    void StartCountdown()
    {
        timer = firstTime;
        timeText.gameObject.SetActive(true);
        canCount = true;
    }

}
