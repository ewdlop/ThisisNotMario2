using UnityEngine;

public class BackgroundMusic : MonoBehaviour {

    public AudioClip[] backgroundMusic;
    public static AudioSource source;
    public AudioClip playingClip;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if(objs.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        playingClip = backgroundMusic[Random.Range(0, backgroundMusic.Length)];
        source = GetComponent<AudioSource>();
        source.clip = playingClip;
        if(source.isActiveAndEnabled)
        {
              source.Play();
        }
        else
        {
            source.enabled = true;
            source.Play();
        }
    }
    void Update()
    {
        
        if (source != null && !source.isPlaying && source.enabled)
        {
            PlayRandomMusic();
        }
    }

    void PlayRandomMusic()
    {

        playingClip = backgroundMusic[Random.Range(0, backgroundMusic.Length)];
        source.clip = playingClip;
        if(source.isActiveAndEnabled)
        {
            source.Play();
        }
        else
        {
            source.enabled = true;
            source.Play();
        }
    }
}
