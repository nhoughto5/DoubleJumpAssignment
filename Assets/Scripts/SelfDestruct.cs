using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 
 *This class is used to set a self destruct behaviour on the 
 * player and enemy lasers. This allows the bullets
 * to be discarded after a set amount of time.  
 * 
 **/
public class SelfDestruct : MonoBehaviour
{

    //Amount of time the bullets are alive
    public float timer = 1f;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            DestroyGameObject();
        }
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
