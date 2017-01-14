using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlayerSpawner : MonoBehaviour
{

    public GameObject playerPrefab;
    GameObject playerInstance;
    float respawnTimer;
    public int numLives = 4;

    private GameManager mGameManager;

    //Used to create a GameManager obect which can be used to call methods.
    private GameManager mGM
    {
        get
        {
            if (mGameManager == null)
            {
                mGameManager = (GameManager)FindObjectOfType(typeof(GameManager));
            }
            return mGameManager;
        }
    }

    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        --numLives;
        respawnTimer = 1.0f;
        

        //Get the smaller of the screen dimensions
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, 0.7f * Screen.height), Camera.main.farClipPlane / 2));
        screenPosition.z = 0;
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
        playerInstance.transform.position = screenPosition;
        mGM.setPlayerHealth(1.0f);
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

    //private void OnGUI()
    //{
    //    if (numLives > 0 || playerInstance != null)
    //    {
    //        GUI.Label(new Rect(0, 0, 100, 50), "Lives: " + numLives);
    //    }
    //    else
    //    {
    //        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height/2 - 25, 100, 50), "Game Over");
    //    }
    //}
}

