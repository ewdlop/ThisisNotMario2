using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour {

    public Text deathCountText;
    //public Text deathUnProtectedCountText;
    //public Text speedXTest;
    //public Text hash;

    //public static int deathUnProtected;
    public static int currentSavePointIndex;
    public GameObject player;
    public GameObject savePoints;
    //public byte[] result;

    void Start() {
        GameEventBroker.OnPlayerRespawned += OnGameRestartedHandler;
        GameEventBroker.OnPlayerDeath += OnPlayerDeathHandler;
    }

    #region for old class
    byte[] ComputeHash(int data)
    {
        byte[] bytes = BitConverter.GetBytes(data);
        SHA512 shaM = new SHA512Managed();
        return shaM.ComputeHash(bytes);
    }
    void SetDeathToMax()
    {
        deathCountText.text = "Death(Protected): ಠ_ಠ";
        GameEventBroker.FreezePlayer();
    }
    public bool Equality(byte[] a1, byte[] b1)
    {
        if (a1.Length != b1.Length)
        {
            return false;
        }
        if (ReferenceEquals(a1, b1))
        {
            return true;
        }
        for (int i = 0; i < a1.Length; i++)
        {
            if (a1[i] != b1[i])
            {
                return false;
            }
        }
        return true;
    }
    #endregion

    void OnGameRestartedHandler(GameObject playerGameObject, int playerDeathCount)
    {
        MovePlayerToRespawnPoint(playerGameObject);
        UpdateDeathText(playerDeathCount);
    }

    void OnPlayerDeathHandler(int playerDeathCount) {
        UpdateDeathText(playerDeathCount);
        GameEventBroker.OnPlayerRespawned -= OnGameRestartedHandler;
        GameEventBroker.OnPlayerDeath -= OnPlayerDeathHandler;
    }

    void UpdateDeathText(in int death)
    {
        #region for old class
        //if (Equality(ComputeHash(death), result)) {
        //    deathCountText.text = "Death: " + death.ToString();
        //} else {
        //    SetDeathToMax();
        //} 
        #endregion
        deathCountText.text = $"RIP: {death}";
    }
    public void ToggleBackgroundMusic()
    {
        if (BackgroundMusic.source == null)
        {
            BackgroundMusic.source = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        }
        BackgroundMusic.source.enabled = !BackgroundMusic.source.enabled;
    }

    public void MovePlayerToRespawnPoint(in GameObject gameObject)
    {
        gameObject.transform.position = savePoints.transform.GetChild(currentSavePointIndex).transform.position;
    }

    #region for old class
    void Update()
    {
       
        //speedXTest.text = "SpeedX: " + player.GetComponent<PlayerMovement>().speedX;
        //deathUnProtectedCountText.text = "Death: " + deathUnProtected.ToString();
        //hash.text = "Hash: " + BitConverter.ToString(result);

    }
    #endregion
}