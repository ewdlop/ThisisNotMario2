using UnityEngine;

public class KillPlayer : MonoBehaviour {

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameEventBroker.KillPlayer();
        }
    }
}
