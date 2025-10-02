using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGame : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            QuitApplication();
        }
    }
    private void QuitApplication()
    {
        Application.Quit();
    }
}
