using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 *  This class is the manager which intercommunicates with 
 *  a series of other scripts to pass messages, handle
 *  score, health, and spawning and handle the
 *  Game Over state
 * 
 **/
public class GameManager : MonoBehaviour
{

    private int score = 0;
    public const int startingLives = 3;
    public int currentLives = startingLives, enemyCount = 0;
    public Text scoreTxt, livesTxt, enemyCountTxt;
    private float playerHealth;
    private HealthBar healthBar;
    public GameObject gameOverMenu;

    //Used to create a GameManager obect which can be used to call methods.
    private HealthBar hB
    {
        get
        {
            if (healthBar == null)
            {
                healthBar = (HealthBar)FindObjectOfType(typeof(HealthBar));
            }
            return healthBar;
        }
    }

    //Used to create a PlayerSpawner obect which can be used to call methods.
    private PlayerSpawner playerSpawner;
    private PlayerSpawner spawner
    {
        get
        {
            if (playerSpawner == null)
            {
                playerSpawner = (PlayerSpawner)FindObjectOfType(typeof(PlayerSpawner));
            }
            return playerSpawner;
        }
    }
    private void Start()
    {
        Restart();
    }

    private void handleHealth()
    {
        hB.setFillAmount(playerHealth);
    }

    public void setPlayerHealth(float playerHealth_)
    {
        playerHealth = playerHealth_;
        handleHealth();
    }

    public void addPoint()
    {
        ++score;
        scoreTxt.text = score.ToString();
    }

    public void lostALife()
    {
        --currentLives;
        livesTxt.text = currentLives.ToString();
        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    // Stop the player spawner and show the game over menu
    private void GameOver()
    {
        spawner.setPlaying(false);
        gameOverMenu.SetActive(true);
    }

    private void DeactivateGameOverGUI()
    {
        gameOverMenu.SetActive(false);
    }

    public void Restart()
    {
        DeactivateGameOverGUI();
        ResetGame();
        spawner.SpawnPlayer();
        spawner.setPlaying(true);
    }

    private void ResetGame()
    {
        List<GameObject> enemies = findAllGameObjectsByLayer("Enemy");
        foreach (GameObject e in enemies)
        {
            Destroy(e);
        }
        playerHealth = 1.0f;
        handleHealth();
        currentLives = startingLives;
        score = 0;
        enemyCount = 0;
        enemyCountTxt.text = enemyCount.ToString();
        livesTxt.text = currentLives.ToString();
        scoreTxt.text = score.ToString();
    }
    public void addEnemy()
    {
        ++enemyCount;
        enemyCountTxt.text = enemyCount.ToString();
    }

    public void enemyDied()
    {
        --enemyCount;
        enemyCountTxt.text = enemyCount.ToString();
    }

    private List<GameObject> findAllGameObjectsByLayer(string layerName)
    {
        List<GameObject> objects = new List<GameObject>();
        GameObject[] gos = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
        int layer = LayerMask.NameToLayer(layerName);
        foreach (GameObject go in gos)
        {
            if (go.layer.Equals(layer))
            {
                objects.Add(go);
            }
        }
        return objects;
    }
}
