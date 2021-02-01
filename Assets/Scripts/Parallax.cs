using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length, startPosition;
    public GameObject camera;
    public float parallaxEffectLvl;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = (camera.transform.position.x * parallaxEffectLvl);
        transform.position = new Vector3(startPosition + dist, transform.position.y, transform.position.z);
    }
}
