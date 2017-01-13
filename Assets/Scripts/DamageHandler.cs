using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public int health = 1;
    float invulnerableTimer = 0;
    public float invulnerableLength = 0.0f;
    int objectDefaultLayer;
    SpriteRenderer spriteRend;

    public Sprite spriteDamaged;


    private void Start()
    {
        objectDefaultLayer = gameObject.layer;

        //This doesn't work for children
        spriteRend = GetComponent<SpriteRenderer>();
        if (spriteRend == null)
        {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();
            if (spriteRend == null)
            {
                Debug.Log("Object '" + gameObject.name + "' has no sprite renderer");
            }
        }
    }

    //Game Object takes damage
    private void OnTriggerEnter2D(Collider2D collision)
    {

        --health;
        invulnerableTimer = invulnerableLength;
        gameObject.layer = LayerMask.NameToLayer("Invulnerable");
        //If this is the player
        if (gameObject.tag.Equals("Player") && health == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteDamaged;
        }
    }
    private void Update()
    {
        invulnerableTimer -= Time.deltaTime;
        if (invulnerableTimer <= 0)
        {
            gameObject.layer = objectDefaultLayer;
            if (spriteRend != null)
            {
                spriteRend.enabled = true;
            }
        }
        else
        {
            //This is all frame dependent
            if (spriteRend != null)
            {
                spriteRend.enabled = !spriteRend.enabled;
            }
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
