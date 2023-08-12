using System;
using UnityEngine;

//public class PlayerEventArgs : EventArgs
//{
//    public GameObject PlayerGameObject{ get; set; }
//    public PlayerEventArgs(in GameObject playerGameObjects) {
//        PlayerGameObject = playerGameObjects;
//    }
//}


public static class GameEventBroker
{
    #region unused
    //public delegate void CustomEventDelegate<T>(int x, out T value);
    //public event CustomEventDelegate<int> CustomEvent;
    //public event EventHandler<PlayerEventArgs> FileFound;
    //public static Action method1;
    //public static Predicate<string> predicate;
    //public static Func<int, int> method2;
    //public static Action OnPlayerHealthLow;
    ///    //public static void CallTest()
    //{
    //    method1?.Invoke();
    //}

    //public static void CallTest2()
    //{
    //    if(method2 != null)
    //    {
    //        _ = method2(2);
    //    }
    //}
    #endregion

    private static Action<int> onPlayerDeath;
    private static Action<GameObject, int> onPlayerRespawned;
    private static Action onKillPlayer;
    private static Action onFreezePlayer;

    private static int playerDeathCount;
    public static int PlayerDeathCount { get => playerDeathCount; set => playerDeathCount = value; }
    public static Action OnFreezePlayer { get => onFreezePlayer; set => onFreezePlayer = value; }
    public static Action OnKillPlayer { get => onKillPlayer; set => onKillPlayer = value; }
    public static Action<GameObject, int> OnPlayerRespawned { get => onPlayerRespawned; set => onPlayerRespawned = value; }
    public static Action<int> OnPlayerDeath { get => onPlayerDeath; set => onPlayerDeath = value; }

    public static void PlayerDeath()
    {
        PlayerDeathCount++;
        OnPlayerDeath?.Invoke(PlayerDeathCount);
    }

    public static void PlayerRespawned(GameObject playerGameObjects) {
        OnPlayerRespawned?.Invoke(playerGameObjects, playerDeathCount);
    }

    public static void FreezePlayer() {
        OnFreezePlayer?.Invoke();
    }

    public static void KillPlayer()
    {
        OnKillPlayer?.Invoke();
    }
}
