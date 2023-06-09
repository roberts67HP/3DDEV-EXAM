using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour {
    void Update () {
        if(GameManager.instance.CurrentState != GameState.Game) {
            enabled = false;
        }
    }

    void OnTriggerEnter (Collider col) {
        if(col.CompareTag("Player")) {
            GameManager.instance.CurrentState = GameState.Lose;
        }
        if(!col.CompareTag("SpawnBox")) {
            Destroy(gameObject);
        }
    }
}
