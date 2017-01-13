using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlayerSpawner : MonoBehaviour
{

    public GameObject playerPrefab;
    GameObject playerInstance;
    float respawnTimer;
    public int numLives = 4;
    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        --numLives;
        respawnTimer = 1.0f;
        

        //Get the smaller of the screen dimensions
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, 0.45f * Screen.width), Random.Range(0, 0.45f * Screen.height), Camera.main.farClipPlane / 2));
        screenPosition.z = 0;
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
        playerInstance.transform.position = screenPosition;
    }

    private void Update()
    {
        if (playerInstance == null && numLives > 0)
        {
            respawnTimer -= Time.deltaTime;
            if (respawnTimer <= 0)
            {
                SpawnPlayer();
            }
        }
    }

    private void OnGUI()
    {
        if (numLives > 0 || playerInstance != null)
        {
            GUI.Label(new Rect(0, 0, 100, 50), "Lives: " + numLives);
        }
        else
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height/2 - 25, 100, 50), "Game Over");
        }
    }
}

