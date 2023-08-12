using UnityEngine;

public class SavePointTriggers : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (transform.GetSiblingIndex() > PlayerStats.currentSavePointIndex)
                PlayerStats.currentSavePointIndex = transform.GetSiblingIndex();
            Destroy(gameObject.GetComponent<BoxCollider2D>());
        }
    }
}
