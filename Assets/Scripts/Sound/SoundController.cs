using UnityEngine.UI;
using UnityEngine;

public enum SFX
{
    Jump,
    Death,
    MushroomSpawn,
    Coin
}

public class SoundController : MonoBehaviour
{
    [SerializeField]
    public AudioClip[] clips;                // Make sure clips are ordered in the same as the enum
    [SerializeField]
    private static AudioSource[] sources;
    private static float masterVolume = 1f;
    private static float bgmVolume = 1f;
    private static float sfxVolume = 1f;
    [SerializeField]
    private Slider masterVolumeSlider;
    [SerializeField]
    private Slider bgmVolumeSlider;
    [SerializeField]
    private Slider sfxVolumeSlider;

    public static AudioSource[] Sources { get => sources; private set => sources = value; }
    public static float MasterVolume { get => masterVolume; private set => masterVolume = value; }
    public static float BgmVolume { get => bgmVolume; private set => bgmVolume = value; }
    public static float SfxVolume { get => sfxVolume; private set => sfxVolume = value; }
    public Slider MasterVolumeSlider { get => masterVolumeSlider; private set => masterVolumeSlider = value; }
    public Slider BgmVolumeSlider { get => bgmVolumeSlider; private set => bgmVolumeSlider = value; }
    public Slider SfxVolumeSlider { get => sfxVolumeSlider; private set => sfxVolumeSlider = value; }

    void Start()
    {
        if (MasterVolumeSlider != null) {
            MasterVolumeSlider.onValueChanged.AddListener((sildervalue) => OnMasterVolumeValueChanged(sildervalue));
            MasterVolumeSlider.value = MasterVolume;
        }
        if (BgmVolumeSlider != null) {
            BgmVolumeSlider.onValueChanged.AddListener((sildervalue) => OnBGMVolumeValueChanged(sildervalue));
            MasterVolumeSlider.value = BgmVolume;
        }
        if (SfxVolumeSlider != null) {
            SfxVolumeSlider.onValueChanged.AddListener((sildervalue) => OnSFXVolumeValueChanged(sildervalue));
            SfxVolumeSlider = SfxVolumeSlider;
        }

        // Set up sfx audio
        Sources = new AudioSource[clips.Length];
        for (int i = 0; i < clips.Length; ++i)
        {
            GameObject child = new GameObject(clips[i].name);
            child.transform.parent = gameObject.transform;
            Sources[i] = child.AddComponent<AudioSource>();
            Sources[i].clip = clips[i];
        }
    }

    public static void Play(int soundIndex)
    {
        Sources[soundIndex].volume = Mathf.Min(SfxVolume, MasterVolume);  // Play at specified volume
        Sources[soundIndex].Play();
    }

    public static void Play(SFX sound)
    {
        Sources[(int)sound].volume = Mathf.Min(SfxVolume, MasterVolume);  // Play at specified volume
        Sources[(int)sound].Play();
    }

    // Play desired clip at specified volume 
    // 1.0f for max volume
    public static void Play(int soundIndex, float volumeLevel)
    {
        volumeLevel = Mathf.Clamp(volumeLevel, 0.0f, 1.0f);
        Sources[soundIndex].volume = volumeLevel * Mathf.Min(SfxVolume, MasterVolume);
        Sources[soundIndex].Play();
    }
    public static void PlayWithOutInterrpution(int soundIndex)
    {
        AudioSource clip = Sources[soundIndex];
        if (!clip.isPlaying)
        {
            clip.volume = Mathf.Min(SfxVolume, MasterVolume);
            clip.Play();
        }
    }

    public void OnMasterVolumeValueChanged(in float value)
    {
        MasterVolume = value;
    }

    public void OnBGMVolumeValueChanged(in float value)
    {
        BgmVolume = value;
    }

    public void OnSFXVolumeValueChanged(in float value)
    {
        SfxVolume = value;
    }
}