using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour
{
    [SerializeField] float movementSpeedX, movementSpeedY;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x - 8 <= GameObject.Find("Girl").transform.position.x)
        {
            transform.position = transform.position + new Vector3(-movementSpeedX, -movementSpeedY, 0);
        }

    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.name == "Terrain")
        {
            movementSpeedY *= -1;
            transform.rotation = Quaternion.Euler(0, 0, 161.222f);
        }
    }

}
