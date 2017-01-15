using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlayerSpawner : MonoBehaviour
{

    public GameObject playerPrefab;
    GameObject playerInstance;
    float respawnTimer;
    bool playing = true;
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
    }

    public void SpawnPlayer()
    {
        respawnTimer = 1.0f;
        

        //Get the smaller of the screen dimensions
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, 0.7f * Screen.height), Camera.main.farClipPlane / 2));
        screenPosition.z = 0;
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
        playerInstance.transform.position = screenPosition;
        mGM.setPlayerHealth(1.0f);
    }

    public void setPlaying(bool p)
    {
        this.playing = p;
    }
    private void Update()
    {
        if (playerInstance == null && playing)
        {
            respawnTimer -= Time.deltaTime;
            if (respawnTimer <= 0)
            {
                SpawnPlayer();
            }
        }
    }
}

