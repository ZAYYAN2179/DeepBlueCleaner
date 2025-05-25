using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private float speed = 4f;
    Vector3 berenang;

    public Animator karakter;

    public bool gameOver = false;

    public int maxHealth = 3;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fish"))
        {
            currentHealth--;
            Debug.Log("Current Health: " + currentHealth);

            Destroy(other.gameObject);
        }
    }
}