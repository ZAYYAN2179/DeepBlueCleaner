using UnityEngine;

public class MovingFish : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Vector3 movementDirection;
    
    void Start()
    {
        // Tentukan arah gerakan berdasarkan rotasi ikan
        if (transform.rotation.eulerAngles.y == 0f)
        {
            // Ikan menghadap kanan, bergerak ke kanan
            movementDirection = Vector3.right;
        }
        else
        {
            // Ikan menghadap kiri, bergerak ke kiri
            movementDirection = Vector3.left;
        }
    }
    
    void Update()
    {
        // Gerakkan ikan sesuai arah yang sudah ditentukan
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        
        // Hancurkan ikan ketika keluar dari layar
        if (transform.position.x >= 25f || transform.position.x <= -25f)
        {
            Destroy(gameObject);
        }
    }
}