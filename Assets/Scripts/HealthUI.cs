using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HealthUI : MonoBehaviour
{
    public GameObject heartPrefab;
    public PlayerController player;
    public Vector2 startPos = new Vector2(0, 0);
    public float spacing = 0f;

    private List<GameObject> hearts = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < player.maxHealth; i++)
        {
            GameObject heart = Instantiate(heartPrefab, transform);
            RectTransform rt = heart.GetComponent<RectTransform>();

            // Letakkan heart dari kanan ke kiri
            rt.anchoredPosition = new Vector2(startPos.x - (spacing * i), startPos.y);

            // Masukkan heart ke depan list (index 0 = paling kanan)
            hearts.Insert(0, heart);
        }
    }

    void Update()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            hearts[i].SetActive(i < player.currentHealth);
        }
    }
}
