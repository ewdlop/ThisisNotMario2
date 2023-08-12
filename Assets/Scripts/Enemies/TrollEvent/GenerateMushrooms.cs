using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMushrooms : MonoBehaviour {

    public GameObject[] mushrooms;
    public GameObject gemBox;
    public SFX mushroomSound;
    public Sprite disableSprite;
    [Header("FlippedBox")]
    public bool isFlipped;
    public GameObject fakeSprite;
    private bool isActivated;

    void OnTriggerStay2D(Collider2D collision)
    {
        if(!isActivated)
        {
            isActivated = true;
            foreach(GameObject mushroom in mushrooms)
            {


                if(mushroom!=null)
                {
                    GameObject spawn = Instantiate(mushroom, gemBox.transform);
                    if (isFlipped)
                    {
                        if (fakeSprite != null)
                        {
                            fakeSprite.GetComponent<SpriteRenderer>().sprite = disableSprite;
                        }
                    }
                    else
                    {
                        gemBox.GetComponent<SpriteRenderer>().sprite = disableSprite;
                    }
                    SoundController.Play(mushroomSound);
                    return;
                }
            }
            Destroy(gameObject);
        }

        
    }
}
