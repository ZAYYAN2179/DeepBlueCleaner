using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel; // panel pause (Raw Image + tombol-tombol)

    void Start()
    {
        pausePanel.SetActive(false); // sembunyikan saat game mulai
        Time.timeScale = 1f; // pastikan game berjalan
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);  // tampilkan UI Pause
        Time.timeScale = 0f;         // hentikan game
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false); // sembunyikan UI Pause
        Time.timeScale = 1f;         // lanjutkan game
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Pastikan timeScale dinormalkan kembali
        SceneManager.LoadScene("SampleScene");
    }
}
