using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [SerializeField]
    private Transform player;
    public Transform Player { get => player; private set => player = value;}

    void Start()
    {
        GameEventBroker.OnPlayerRespawned += (playerGameObject, playerDeathCount) => FollowerPlayerHandler(playerGameObject, playerDeathCount);
        GameEventBroker.OnPlayerDeath += OnPlayerDeathHandler;
    }
    void FollowerPlayerHandler(GameObject playerGameObject, int playerDeathCount)
    {
        FollowPlayer(playerGameObject);
    }
    void FollowPlayer(in GameObject playerGameObject)
    {
        Player = playerGameObject.transform;
    }

    void OnPlayerDeathHandler(int playerDeathCount) {
        GameEventBroker.OnPlayerRespawned -= FollowerPlayerHandler;
        GameEventBroker.OnPlayerDeath -= OnPlayerDeathHandler;
    }

    void Update ()
    {
        if (Player != null) transform.position = new Vector3(Player.position.x,transform.position.y,transform.position.z);
	}
}
