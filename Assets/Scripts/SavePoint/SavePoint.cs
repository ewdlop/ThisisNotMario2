using UnityEngine;

public class SavePoint : MonoBehaviour {

    public int defaultSavePointIndex;
    private static bool loaded = false;

    void Start()
    {
        if (!loaded)
        {
            loaded = true;
            PlayerStats.currentSavePointIndex = defaultSavePointIndex;
        }
    }
}
