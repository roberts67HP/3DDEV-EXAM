using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    Game,
    Lose
}

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public event Action OnGameLose;

    private GameState state;
    public GameState CurrentState {
        get => state;
        set {
            if (value != state) {
                SetState(value);
            }
        }
    }

    ///////INSPECTOR VARIABLES

    [SerializeField] public TimeTracker timeTracker;

    ///////RUNTIME VARIABLES

    private bool gameOn = false;

    void Awake () => instance = this;

    // Start is called before the first frame update
    void Start() {
        // PlayerPrefs.SetInt("BestTime", 0);
        // PlayerPrefs.Save();
    }
    private void SetState (GameState newState) {
        state = newState;
        switch (state) {
            case GameState.Game :
                OnGameStart();
                break;
            case GameState.Lose :
                OnGameLose?.Invoke();
                break;
            default :
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }
    void OnGameStart () {
        Debug.Log("Start");
    }

    void Update() {
        if(!gameOn) {
            gameOn = true;
            SetState(GameState.Game);
        }
    }
}
