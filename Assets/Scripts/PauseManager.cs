using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseBackground;

    void Start()
    {
        pausePanel.SetActive(false);
        pauseBackground.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        pauseBackground.SetActive(true);
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        pauseBackground.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
}