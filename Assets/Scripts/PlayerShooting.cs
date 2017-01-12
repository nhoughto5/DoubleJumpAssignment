using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
    float coolDownTimer = 0;
    float fireDelay = 0.25f;
    public GameObject bulletPrefab;
    private bool alternatingGun = false;
    Vector3 portGunOffset, starboardGunOffset, bowGunOffset;
    // Use this for initialization
    void Start () {
        Transform[] children = transform.GetComponentsInChildren<Transform>();
        portGunOffset = children[1].position - transform.position;
        starboardGunOffset = children[2].position - transform.position;
        bowGunOffset = children[3].position - transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        coolDownTimer -= Time.deltaTime;
        if (Input.GetButton("Fire1") && coolDownTimer <= 0)
        {
            coolDownTimer = fireDelay;
            if (alternatingGun)
            {
                Vector3 position = transform.position + (transform.rotation * portGunOffset);
                GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, position, transform.rotation);
                bulletGO.layer = gameObject.layer;
            }
            else
            {
                Vector3 position = transform.position + (transform.rotation * starboardGunOffset);
                GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, position, transform.rotation);
                bulletGO.layer = gameObject.layer;
            }
            alternatingGun = !alternatingGun;
        }
	}
}
