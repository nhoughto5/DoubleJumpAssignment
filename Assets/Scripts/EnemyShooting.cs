using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {
    Vector3 gunOffset;
    float coolDownTimer = 0;
    public GameObject bulletPrefab;
    float fireDelay = 1.5f;
    int bulletLayer;
    Transform player;
    public float fireDistance = 3.0f;
    // Use this for initialization
    void Start () {
        Transform[] children = transform.GetComponentsInChildren<Transform>();
        gunOffset = children[1].position - transform.position;
        bulletLayer = gameObject.layer;
    }
	
	// Update is called once per frame
	void Update () {
        if (player == null)
        {
            GameObject go = GameObject.FindWithTag("Player");
            if (go != null)
            {
                player = go.transform;
            }
        }

        coolDownTimer -= Time.deltaTime;
        float randomFire = Random.Range(fireDistance/2, fireDistance);
        if (coolDownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < randomFire)
        {
            coolDownTimer = fireDelay;
            Vector3 position = transform.position + (transform.rotation * gunOffset);
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, position, transform.rotation);
            bulletGO.layer = bulletLayer;
        }
	}
}
