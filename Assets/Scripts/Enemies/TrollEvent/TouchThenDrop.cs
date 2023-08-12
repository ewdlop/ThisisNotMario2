using UnityEngine;

public class TouchThenDrop : MonoBehaviour
{

    private Rigidbody2D rb;
    private bool isDropping;
    public bool isCanDropByEnemies;
    public float droppingStrength;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isDropping = true;
            Destroy(gameObject, 5f);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemies" && isCanDropByEnemies) {
            isDropping = true;
            Destroy(gameObject, 5f);
        }
    }

    private void Update()
    {
        if(isDropping)
        {
            transform.Translate(0f, droppingStrength * Time.deltaTime, 0f);
        }
    }
}
