using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] public float startSpawnSeconds = 6f;
    [SerializeField] public float waitTimeBeforeDecrease = 1f;
    [SerializeField] public float spawnSecondsDecrease = 0.1f;
    [SerializeField] public List<GameObject> fallingObjects;

    private bool spawnedFallingObject = false;
    private bool decreasingTime = false;

    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if(GameManager.instance.CurrentState == GameState.Game) {
            if(!spawnedFallingObject) {
                StartCoroutine(CubeSpawnCoroutine());
            }
            if(startSpawnSeconds > 0.2) {
                if(!decreasingTime) {
                    StartCoroutine(TimeDecreaseCoroutine());
                }
            }
        }
    }
    IEnumerator CubeSpawnCoroutine () {
        spawnedFallingObject = true;

        SpawnFallingObject();
        yield return new WaitForSeconds(startSpawnSeconds);

        spawnedFallingObject = false;
    }
    IEnumerator TimeDecreaseCoroutine () {
        decreasingTime = true;

        yield return new WaitForSeconds(waitTimeBeforeDecrease);
        startSpawnSeconds -= spawnSecondsDecrease;
        Debug.Log(startSpawnSeconds);

        decreasingTime = false;
    }

    void SpawnFallingObject () {
        Bounds bounds = GetComponent<Collider>().bounds;
        float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
        float offsetY = Random.Range(-bounds.extents.y, bounds.extents.y);
        float offsetZ = Random.Range(-bounds.extents.z, bounds.extents.z);

        int index = (int) Random.Range(0, fallingObjects.Count);

        GameObject obj = GameObject.Instantiate(fallingObjects[index]);
        obj.transform.position = bounds.center + new Vector3(offsetX, offsetY, offsetZ);
    }
}
