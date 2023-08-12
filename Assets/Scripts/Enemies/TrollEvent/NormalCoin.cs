using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCoin : MonoBehaviour {

    public SFX coinSound;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundController.Play(coinSound);
            Object.Destroy(gameObject);
        }
    }
}
