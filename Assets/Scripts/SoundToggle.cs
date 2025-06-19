using UnityEngine;

public class SoundToggle : MonoBehaviour
{
    public GameObject soundOnButton;
    public GameObject soundOffButton;
    public AudioSource audioSource;

    private bool isPaused = false;

    void Start()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play(); // Mainkan sekali di awal
        }

        soundOnButton.SetActive(true);
        soundOffButton.SetActive(false);
    }

    public void ToggleSoundOff()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause(); // Ini hanya menjeda, tidak mengulang
            isPaused = true;
        }

        soundOnButton.SetActive(false);
        soundOffButton.SetActive(true);
    }

    public void ToggleSoundOn()
    {
        if (isPaused)
        {
            audioSource.UnPause(); // Lanjut dari titik terakhir
        }

        soundOnButton.SetActive(true);
        soundOffButton.SetActive(false);
        isPaused = false;
    }
}
