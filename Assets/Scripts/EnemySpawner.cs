using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float enemyRate = 8.0f;
    private float speedUpRate = 0.7f;
    float timeUntilSpawn = 1;
    public GameObject enemyPrefab;
    public float spawnDistance = 20f;
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
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0)
        {

            addEnemyAndIncreaseRate();
        }
    }

    private void addEnemyAndIncreaseRate()
    {
        timeUntilSpawn = enemyRate;
        enemyRate *= speedUpRate;
        if (enemyRate < 2)
        {
            enemyRate = 2;
        }
        addEnemy();
    }
    private void addEnemy()
    {
        Vector3 offset = Random.onUnitSphere;
        offset.z = 0;
        offset = offset.normalized * spawnDistance;
        Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
        mGM.addEnemy();
    }
}
