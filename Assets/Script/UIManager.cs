using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    [SerializeField] private TimeTracker timeTracker;
    [SerializeField] private RectTransform losePanel;
    [SerializeField] private TMPro.TextMeshProUGUI finalTimeText;

    void Start() {
        GameManager.instance.OnGameLose += OnGameLose;
    }
    void OnDestroy () {
        GameManager.instance.OnGameLose -= OnGameLose;
    }
    void OnGameLose() {
        if (timeTracker.seconds > timeTracker.bestTime) {
            PlayerPrefs.SetInt("BestTime", timeTracker.seconds);
            PlayerPrefs.Save();

            timeTracker.bestTime = timeTracker.seconds;
        }

        finalTimeText.text = "Final time: "+timeTracker.seconds+"\nBest time: "+timeTracker.bestTime;
        losePanel.gameObject.SetActive(true);
    }

    void Update() {
        
    }

    public void TryAgainButton () {
        SceneManager.LoadScene(1);
    }
    public void QuitButton () {
        SceneManager.LoadScene(0);
    }
}
