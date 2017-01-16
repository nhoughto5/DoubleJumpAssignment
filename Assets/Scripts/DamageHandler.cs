using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/**
 * This class handles the damage computation for each game object.
 * When the player reaches a certain health level the sprite is switched
 * for the damaged version.
 * */
public class DamageHandler : MonoBehaviour
{
    public float health = 1.0f, damageSpriteHealthLevel = 0.25f;
    public float enemyLaserDamage = 0.25f, playerLaserDamage = 1.0f;
    float invulnerableTimer = 0;
    public float invulnerableLength = 0.0f;
    int objectDefaultLayer;
    SpriteRenderer spriteRend;
    public GameObject ExplosionGO;

    public Sprite spriteDamaged;
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

    void PlayExplosion(Vector3 collisionLocation)
    {
        GameObject expl = (GameObject)Instantiate(ExplosionGO);
        expl.transform.position = collisionLocation;
    }
    //Game Object takes damage
    private void OnTriggerEnter2D(Collider2D collision)
    {


        invulnerableTimer = invulnerableLength;
        gameObject.layer = LayerMask.NameToLayer("Invulnerable");

        //Deal with the collision from the perspective of the ships
        if (!gameObject.tag.Equals("Laser"))
        {
            //Explosions should not play when it is a laser/laser collision
            PlayExplosion(collision.transform.position);

            //Collision between player's laser and an enemy
            if (gameObject.gameObject.tag.Equals("Enemy") && collision.gameObject.tag.Equals("Laser"))
            {
                health -= playerLaserDamage;
                addPoint();
            }

            //Collision between enemy's laser and the player
            if (gameObject.gameObject.tag.Equals("Player") && collision.gameObject.tag.Equals("Laser"))
            {
                health -= enemyLaserDamage;
                mGM.setPlayerHealth(health);
            }

            //If Collision between enemy and player
            if (gameObject.gameObject.tag.Equals("Player") && collision.gameObject.tag.Equals("Enemy"))
            {
                health = 0.0f;
                mGM.setPlayerHealth(health);
                Destroy(collision.gameObject);
                mGM.enemyDied();
                mGM.addPoint();
            }

        }
        //If this is the player and is on the final hit point show the damaged sprite.
        if (gameObject.tag.Equals("Player") && health <= damageSpriteHealthLevel)
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
        //Collision between enemy laser and player
        if (gameObject.tag.Equals("Player"))
        {
            lostLife();
        }
        if (gameObject.tag.Equals("Enemy"))
        {
            enemyDied();
        }
        Destroy(gameObject);
    }

    private void lostLife()
    {
        mGM.lostALife();
    }
    private void addPoint()
    {
        mGM.addPoint();
    }
    private void enemyDied()
    {
        mGM.enemyDied();
    }
}
