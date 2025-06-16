using UnityEngine;

public class MovingTrash : MonoBehaviour
{
    public float speed = 40.0f;
    public float rotationSpeed = 90.0f;
    private bool isBlocked = false; // Untuk menghentikan gerakan

    void Update()
    {
        if (!isBlocked)
        {
            // Gerak ke bawah
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);

            // Rotasi
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BatuKarang"))
        {
            isBlocked = true;
        }
    }
}
