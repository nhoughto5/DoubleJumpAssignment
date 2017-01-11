using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
    float coolDownTimer = 0;
    float fireDelay = 0.25f;
    public GameObject bulletPrefab;
    private bool alternatingGun = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        coolDownTimer -= Time.deltaTime;
        if (Input.GetButton("Fire1") && coolDownTimer <= 0)
        {
            coolDownTimer = fireDelay;
            
            Transform[] children = transform.GetComponentsInChildren<Transform>();
            Debug.Log("Fire, Number Children" + children.Length);
            
            Vector3 portGunOffset = children[1].position;
            Vector3 starboardGunOffset = children[2].position;
            Vector3 bowGunOffset = children[3].position;
            if (alternatingGun)
            {
                Instantiate(bulletPrefab, transform.position + portGunOffset, transform.rotation);
            }
            else
            {
                Instantiate(bulletPrefab, transform.position + starboardGunOffset, transform.rotation);
            }
            alternatingGun = !alternatingGun;
        }
	}
}
