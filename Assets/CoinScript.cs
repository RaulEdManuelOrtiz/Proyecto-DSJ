using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinScript : MonoBehaviour
{
    public static int collectedCoins = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            collectedCoins++;
            if (collectedCoins == 3)
            {
                collectedCoins = 0;
                SceneManager.LoadScene("WinScene");
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
