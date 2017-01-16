using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * The PlayerShooting class handles the firing mechanism for the player.
 * The left and right guns are targeted as offsets on initialization.
 * They are located by searching the ship objects children.
 **/
public class PlayerShooting : MonoBehaviour {
    float coolDownTimer = 0;
    float fireDelay = 0.25f;
    public GameObject bulletPrefab;
    private bool alternatingGun = false;
    Vector3 portGunOffset, starboardGunOffset; 
    int bulletLayer;
    
    void Start () {
        Transform[] children = transform.GetComponentsInChildren<Transform>();
        portGunOffset = children[1].position - transform.position;
        starboardGunOffset = children[2].position - transform.position;
        bulletLayer = gameObject.layer;
    }
	
	// Fire the guns alternating left-right.
	void Update () {
        coolDownTimer -= Time.deltaTime;

        // Look at the marked buttons list, not input keys. 
        // This allows the user to change the fire key without having to change any code. 
        if (Input.GetButton("Fire1") && coolDownTimer <= 0)
        {
            coolDownTimer = fireDelay;
            if (alternatingGun)
            {
                Vector3 position = transform.position + (transform.rotation * portGunOffset);
                GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, position, transform.rotation);
                bulletGO.layer = bulletLayer;
            }
            else
            {
                Vector3 position = transform.position + (transform.rotation * starboardGunOffset);
                GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, position, transform.rotation);
                bulletGO.layer = bulletLayer;
            }
            alternatingGun = !alternatingGun;
        }
	}
}
