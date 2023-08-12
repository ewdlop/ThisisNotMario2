using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {

    public Sprite sprite;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
            GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }

}
