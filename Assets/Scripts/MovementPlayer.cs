using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float speed;
    float speedX, speedY;
    Rigidbody2D rb;

    public Projectile projectilePrefab;
    public Transform LaunchOffset;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * speed;
        speedY = Input.GetAxisRaw("Vertical") * speed;
        rb.velocity = new Vector2(speedX, speedY);

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectilePrefab, LaunchOffset.position, transform.rotation);
        }
    }
}
