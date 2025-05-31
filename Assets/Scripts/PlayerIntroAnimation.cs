using UnityEngine;

public class PlayerIntroAnimation : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(0, 0, 0);
    public float speed = 2f;
    public bool animationFinished = false;


    public Vector3 triggerPosition  = new Vector3(0, 17, 0);
    public float triggerRadius = 1f;
    private AudioSource audioSource;
    private bool soundPlayed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

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
                GetComponent<PlayerController>().enabled = true;
            }

            if (!soundPlayed && Vector3.Distance(transform.position, triggerPosition) < triggerRadius)
            {
                audioSource.Play();
                soundPlayed = true;
            }
        }
    }
}
