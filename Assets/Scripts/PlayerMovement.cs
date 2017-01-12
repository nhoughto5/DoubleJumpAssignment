using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 5.0f;
    public float rotSpeed = 180f;
    float shipBoundary = 0.7f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    // Reading of input
    void Update()
    {
        //Rotation
        Quaternion rot = transform.rotation;
        float rotZ = rot.eulerAngles.z;
        rotZ -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, rotZ);
        transform.rotation = rot;

        //Y axis
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        pos += rot * velocity;
        //Restrict player to camera space
        if (pos.y + shipBoundary > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - shipBoundary;
        }
        if (pos.y - shipBoundary < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + shipBoundary;
        }

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;
        if (pos.x + shipBoundary > widthOrtho)
        {
            pos.x = widthOrtho - shipBoundary;
        }
        if (pos.x - shipBoundary < -widthOrtho)
        {
            pos.x = -widthOrtho + shipBoundary;
        }
        transform.position = pos;
        //transform.Translate(new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0));


    }

    private void FixedUpdate()
    {

    }
}
