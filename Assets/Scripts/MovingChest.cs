using Unity.VisualScripting;
using UnityEngine;

public class MovingChest : MonoBehaviour
{
    public float speed = 40.0f;
    public float rotationSpeed = 90.0f;

    void Update()
    {
        // Gerak ke bawah
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
        // Rotasi
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        if (transform.position.y < -15f)
        {
            Destroy(gameObject);
        }
    }

    
}
