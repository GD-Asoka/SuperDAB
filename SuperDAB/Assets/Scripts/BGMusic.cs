using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    // Reference to the audio source component.
    private AudioSource audioSource;

    // The background music clip.
    public AudioClip backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        // Get the AudioSource component attached to this GameObject.
        audioSource = GetComponent<AudioSource>();

        // Set the background music clip.
        audioSource.clip = backgroundMusic;

        // Play the background music on loop.
        audioSource.loop = true;
        audioSource.Play();
    }

    // You can add additional methods to control the music, like pausing, stopping, or changing volume, if needed.
    // For example, you can create a method to pause the music:
    public void PauseMusic()
    {
        audioSource.Pause();
    }

    // And a method to resume the music:
    public void ResumeMusic()
    {
        audioSource.UnPause();
    }
}
