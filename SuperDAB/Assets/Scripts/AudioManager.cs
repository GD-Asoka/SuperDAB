using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager AM_instance;
    public AudioSource audioSource;

    [SerializeField] private AudioClip _defaultBGM;

    public enum BGMState
    {
        Default,
        RunningOutOfTime,
        DoingWell,
        Calm
    }

    private BGMState _bgmState = BGMState.Default;

    private void Awake()
    {
        if(AM_instance)
        {
            Destroy(AM_instance.gameObject);
        }
        else
        {
            AM_instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        audioSource = this.GetComponent<AudioSource>();
    }

    private void Start()
    {
        UpdateBGM(BGMState.Default);
    }

    public void UpdateBGM(BGMState state)
    {
        audioSource.loop = true;
        switch (state)
        {
            case BGMState.Default:
                audioSource.clip = _defaultBGM;
                break;
            default:
                audioSource.clip = _defaultBGM;
                break;
        }
        audioSource.Play();
    }
}
