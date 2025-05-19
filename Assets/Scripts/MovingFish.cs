using UnityEngine;

public class MovingFish : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    void Start()
    {
        float randomY = Random.Range(-4f, 4f);
        transform.position = new Vector3(11f, randomY, 0f);
        transform.rotation = Quaternion.Euler(0f, -180f, 0f);
    }

    void Update()
    {
        // Gerakkan ikan ke kiri karena objek di rotate
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (transform.position.x <= -14f)
        {
            Destroy(gameObject);
        }
    }
}
