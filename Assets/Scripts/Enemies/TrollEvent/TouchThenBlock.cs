using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchThenBlock : MonoBehaviour {

    public GameObject invisibleBlock;
    private SpriteRenderer sr;
    public float knockBackStrength;
    void Start()
    {
        sr = invisibleBlock. GetComponent<SpriteRenderer>();
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sr.enabled = true;
            collision.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0f, -1f * knockBackStrength);
            GameEventBroker.FreezePlayer();
        }
    }
}
