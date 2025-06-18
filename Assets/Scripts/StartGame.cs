using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void LoadStartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
