using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This class rotates enemies towards the player.
 * This, combined with the MoveFoward script give the impression
 *  of a chase behaviour
 * */
public class FacesPlayer : MonoBehaviour
{

    Transform player;
    public float rotationSpeed = 90f;

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            //Find the player
            GameObject playerObject = GameObject.FindWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        }
        if (player == null)
        {
            return;
        }

        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.Normalize();
        float zAngle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg - 90;

        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotationSpeed * Time.deltaTime);
    }
}
