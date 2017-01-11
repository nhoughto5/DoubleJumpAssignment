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
        portGunOffset = children[1].position;
        starboardGunOffset = children[2].position;
        bowGunOffset = children[3].position;
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
                Instantiate(bulletPrefab, position, transform.rotation);
                Debug.Log("port: " + portGunOffset.ToString());
            }
            else
            {
                Vector3 position = transform.position + (transform.rotation * starboardGunOffset);
                Instantiate(bulletPrefab, position, transform.rotation);
                Debug.Log("starboard: " + starboardGunOffset.ToString());
            }
            alternatingGun = !alternatingGun;
        }
	}
}
