using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    public Sprite levelerOnSprite;    // Sprite shown when the lever is activated
    public GameObject disableObject;  // Object to be destroyed upon activation
    private bool isTriggered = false; // Flag to check if the lever has been triggered

    private void OnTriggerStay2D(Collider2D collision)
    {
        // When 'E' key is pressed and the lever hasn't been triggered yet
        if (Input.GetKeyDown(KeyCode.E) && !isTriggered)
        {
            ActivateLever();
        }
    }

    /// <summary>
    /// Handles the logic for activating the lever
    /// </summary>
    private void ActivateLever()
    {
        isTriggered = true;

        // Destroy the target object
        if (disableObject != null)
        {
            Destroy(disableObject);
        }

        // Change the sprite of the lever, if a SpriteRenderer is attached
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null && levelerOnSprite != null)
        {
            sr.sprite = levelerOnSprite;
        }
        else
        {
            Debug.LogWarning("No SpriteRenderer attached to the lever, or no activation sprite assigned.");
        }
    }
}
