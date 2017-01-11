using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public int health = 1;
    float invulnerableTimer = 0;
    public float invulnerableLength = 0.0f;
    int objectDefaultLayer;

    private void Start()
    {
        objectDefaultLayer = gameObject.layer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger!");

        --health;
        invulnerableTimer = invulnerableLength;
        gameObject.layer = LayerMask.NameToLayer("Invulnerable");
    }
    private void Update()
    {
        invulnerableTimer -= Time.deltaTime;
        if (invulnerableTimer <= 0)
        {
            gameObject.layer = objectDefaultLayer;
        }
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
