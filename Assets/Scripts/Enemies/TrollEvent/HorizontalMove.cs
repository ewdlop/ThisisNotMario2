using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour {

    public float speedX;
    public bool isBounceOffWall;
    private Rigidbody2D rb;
	void Start () {
        transform.localScale = new Vector3(
            -1 * transform.localScale.x * speedX / Mathf.Abs(speedX),
            transform.localScale.y,
            transform.localScale.z);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speedX, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemiesBounceWall")
        {
            if(isBounceOffWall)
            {
                transform.localScale = new Vector3(
                -1 * transform.localScale.x,
                transform.localScale.y,
                transform.localScale.z);
                rb = GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(-1f * rb.velocity.x, 0f);
            }
            
        }
    }
}
