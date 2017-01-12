using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {
    Vector3 gunOffset;
    float coolDownTimer = 0;
    public GameObject bulletPrefab;
    float fireDelay = 0.5f;
    // Use this for initialization
    void Start () {
        Transform[] children = transform.GetComponentsInChildren<Transform>();
        gunOffset = children[1].position - transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        coolDownTimer -= Time.deltaTime;
        if (coolDownTimer <= 0)
        {
            coolDownTimer = fireDelay;
            Vector3 position = transform.position + (transform.rotation * gunOffset);
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, position, transform.rotation);
            bulletGO.layer = gameObject.layer;
        }
	}
}
