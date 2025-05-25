using UnityEngine;

public class PlayerIntroAnimation : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(0, 0, 0); // posisi tengah
    public float speed = 2f;
    public bool animationFinished = false;

    void Start()
    {
        // Disable kontrol selama animasi
        GetComponent<PlayerController>().enabled = false;
    }

    void Update()
    {
        if (!animationFinished)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                animationFinished = true;
                // Aktifkan kontrol setelah animasi selesai
                GetComponent<PlayerController>().enabled = true;
            }
        }
    }
}
