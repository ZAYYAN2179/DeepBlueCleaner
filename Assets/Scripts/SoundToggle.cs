using UnityEngine;

public class SoundToggle : MonoBehaviour
{
    public GameObject soundOnButton;
    public GameObject soundOffButton;
    public AudioSource audioSource;

    public void ToggleSoundOn()
    {
        audioSource.Play();                 
        soundOffButton.SetActive(false);   
        soundOnButton.SetActive(true);     
    }

    public void ToggleSoundOff()
    {
        audioSource.Pause();              
        soundOnButton.SetActive(false);    
        soundOffButton.SetActive(true);    
    }
}
