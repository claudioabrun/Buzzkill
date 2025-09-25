using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementPlayer : MonoBehaviour
{
    public float speed = 5;
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
        speedX = speed;
        speedY = Input.GetAxisRaw("Vertical") * (speed + 5);
        rb.velocity = new Vector2(speedX, speedY);

        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(projectilePrefab, LaunchOffset.position, transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartCurrentScene();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        RestartCurrentScene();
    }
    public void RestartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
