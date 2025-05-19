using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private float speed = 4f;
    Vector3 berenang;

    public Animator karakter;

    void Start()
    {

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
        float minX = -10f, maxX = 10f;
        float minY = -3.5f, maxY = 3.5f;

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}