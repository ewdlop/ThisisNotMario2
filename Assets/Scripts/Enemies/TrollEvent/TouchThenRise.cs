using UnityEngine;

public class TouchThenRise : MonoBehaviour {

    public float risingStrength;
    public bool isTriggered;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isTriggered)
        {
            if (collision.gameObject.tag == "Player")
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, risingStrength);
                Rigidbody2D collisonRB = collision.gameObject.GetComponent<Rigidbody2D>();
                collisonRB.velocity = new Vector2(0f, risingStrength + collisonRB.gravityScale);
                GameEventBroker.FreezePlayer();
            }
            isTriggered = true;
        }

    }
}
