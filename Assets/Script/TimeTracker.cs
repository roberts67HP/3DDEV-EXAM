using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTracker : MonoBehaviour {
    [SerializeField] public TMPro.TextMeshProUGUI timePassedText;

    private float timePassed = 0.0f;
    
    [HideInInspector] public int seconds = 0;
    [HideInInspector] public int bestTime = 0;

    // Start is called before the first frame update
    void Start() {
        bestTime = PlayerPrefs.GetInt("BestTime", 0);
    }

    // Update is called once per frame
    void Update() {
        if(GameManager.instance.CurrentState == GameState.Game) {
            timePassed += Time.deltaTime;
            seconds = (int) timePassed % 60;

            timePassedText.text = "Time passed: "+seconds;
        }
    }
}
