using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private int score = 0;
    public int lives = 4, enemyCount = 0;
    public Text scoreTxt, livesTxt, enemyCountTxt;
    private float playerHealth;
    public enum GameManagerState
    {
        Opening, Gameplay, GameOver
    }

    private HealthBar healthBar;

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

    GameManagerState GMState;
    // Use this for initialization
    void Start () {
        GMState = GameManagerState.Opening;
        scoreTxt.text = score.ToString();
        livesTxt.text = lives.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        
	}
    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:
                break;
            case GameManagerState.Gameplay:
                break;
            case GameManagerState.GameOver:
                break;
            default:
                break;
        }
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
        --lives;
        livesTxt.text = lives.ToString();
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
}
