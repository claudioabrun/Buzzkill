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

    private bool isGameOver = false; // Flag to prevent unwanted restarts

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movement
        speedX = speed;
        speedY = Input.GetAxisRaw("Vertical") * (speed + 5);
        rb.velocity = new Vector2(speedX, speedY);

        // Shooting
        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(projectilePrefab, LaunchOffset.position, transform.rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Player hits an enemy: destroy and restart scene
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Hazard")) // Or CloseGame object
        {
            // Player hits a hazard: destroy and trigger GameOver
            isGameOver = true;
            Destroy(gameObject);
            SceneManager.LoadScene("_GameOver");
        }
    }

    private void OnDestroy()
    {
        // Only restart the scene if it wasn't a GameOver
        if (!isGameOver)
        {
            RestartCurrentScene();
        }
    }

    public void RestartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

