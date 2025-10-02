using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseGame : MonoBehaviour
{
    [SerializeField] private string gameOverScene = "_GameOver";
    [SerializeField] private int forceIndex = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision detected with Player");
            Debug.Log("Current Scene: " + SceneManager.GetActiveScene().name);
            Debug.Log("Trying to load scene by name: " + gameOverScene);
            Debug.Log("Trying to load scene by index: " + forceIndex);

            SceneManager.LoadScene(forceIndex, LoadSceneMode.Single);
        }
    }
}
