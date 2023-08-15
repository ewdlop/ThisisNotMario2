using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    public GameObject objectToPush;
    public bool shouldDestoryGameObject;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(shouldDestoryGameObject)
        {
            Destroy(gameObject);
        }
        Debug.Log("Pushing");
        objectToPush?.GetComponent<Rigidbody2D>()?.AddForce(new Vector2(5f,0f), ForceMode2D.Impulse);
    }
}
