using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEnemies : MonoBehaviour
{
    public GameObject[] spawnList;

    private void OnTriggerStay2D(Collider2D collision) {
        Destroy(gameObject);
        foreach(GameObject gameObject in spawnList ) {
            gameObject.SetActive(true);
        }
    }
}
