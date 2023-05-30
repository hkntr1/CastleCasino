using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private UIController uIController;
    public GameState eState;
    public static event Action<GameState> OnGameStateChanged;
    #region

    public static StateManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion
    private void Start()
    {
        UpdateGameState(GameState.Game);
    }
    public void UpdateGameState(GameState newState)
    {
        eState = newState;
        switch (newState)
        {
            case GameState.Game:
            break;
            case GameState.Fail:
                Fail();
            break;
            case GameState.Win:
               Win();
                break;
        }
        OnGameStateChanged?.Invoke(newState);
    }
    private void Fail()
    {
        uIController.Fail();
        DOTween.Kill("Yoyo");
    }
    private void Win()
    {
        uIController.Win();
        DOTween.Kill("Yoyo");
    }

    public enum GameState
    {
        Game,
        Fail,
        Win,
    }
}
