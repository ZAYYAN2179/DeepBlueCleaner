using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public PlayerController player;

    void Start()
    {
        
    }

    void Update()
    {
        scoreText.text = "Score: " + player.currentScore.ToString();
    }
}
