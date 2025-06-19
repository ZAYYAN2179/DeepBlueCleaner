using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Player
    private float speed = 4f;
    Vector3 berenang;
    public Animator karakter;


    // Health
    public int maxHealth = 0;
    public int damage = 0;
    public int currentHealth;
    public HealthBar healthBar;


    // Breath
    public int maxBreath = 0;
    public int currentBreath;
    public BreathBar breathBar;
    public float breathDecreaseRate = 1f; // seconds
    private float breathTimer;


    // Oxygen Effects
    public GameObject oxygenEffectUI; // Drag Panel merah ke sini
    public float effectDuration = 0.5f;


    // Score
    public int score = 0;
    public int currentScore;

    //Fungsi Pause
    private bool IsGamePaused => Time.timeScale == 0f;

    //Fungsi Game Over
    public GameObject gameOverText;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentBreath = maxBreath;
        breathBar.SetMaxBreath(maxBreath);
        breathTimer = breathDecreaseRate;

        currentScore = score;
    }

    void Update()
    {
        if (IsGamePaused)
            return; // Jika game sedang pause, hentikan seluruh logic

        berenang.x = Input.GetAxisRaw("Horizontal");
        berenang.y = Input.GetAxisRaw("Vertical");
        transform.position += berenang * speed * Time.deltaTime;

        if (berenang.x != 0)
        {
            karakter.SetBool("Swim", true);
        }
        else
        {
            karakter.SetBool("Swim", false);
        }

        if (berenang == Vector3.left)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (berenang == Vector3.right)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        // Batas gerak player
        float minX = -14.23f, maxX = 14.23f;
        float minY = -8f, maxY = 8f;

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;

        // Oksigen
        breathTimer -= Time.deltaTime;
        if (breathTimer <= 0f)
        {
            breathTimer = breathDecreaseRate;

            if (currentBreath >= 0)
            {
                currentBreath--;
                breathBar.SetBreath(currentBreath);

                Debug.Log("Current Breath: " + currentBreath);
            }
            else
            {
                currentHealth -= damage;
                healthBar.SetHealth(currentHealth);

                StartCoroutine(ShowOxygenEffect());
            }
        }

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            healthBar.SetHealth(currentHealth);
            GameOver();
        }
    }


    private IEnumerator ShowOxygenEffect()
    {
        if (oxygenEffectUI != null)
        {
            oxygenEffectUI.SetActive(true);
            yield return new WaitForSeconds(effectDuration);
            oxygenEffectUI.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fish"))
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            Debug.Log("Current Health: " + currentHealth);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Trash"))
        {
            TrashItem trash = other.GetComponent<TrashItem>();
            
            currentScore += trash.trashScore;

            Debug.Log("Sampah : " + currentScore);

            Destroy(other.gameObject);
        }
    }

    //fungsi pengurangan nafas
    public void ReduceBreath(int amount)
    {
        currentBreath -= amount;
        if (currentBreath < 0) currentBreath = 0;
        breathBar.SetBreath(currentBreath);
    }

    public void GameOver()
    {
        // Nonaktifkan player
        gameObject.SetActive(false);

        // Tampilkan Game Over Text
        if (gameOverText != null)
        {
            gameOverText.SetActive(true);
        }

        // Pause game
        Time.timeScale = 0f;
    }
}