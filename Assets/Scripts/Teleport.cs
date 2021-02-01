using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public KeyCode[] combo;
    public int currentIndex;

    public Vector3 tele = new Vector3(175f, -1.5f, 0f);

    private bool hasTpEd;

    // Start is called before the first frame update
    private void Update()
    {
        if (currentIndex < combo.Length)
        {
            if (Input.GetKeyDown(combo[currentIndex]))
                currentIndex++;
        }
        else
        {
            if (!hasTpEd)
            {
                hasTpEd = true;
                GetComponent<Rigidbody2D>().gravityScale = 0.5f;
            }

            hasTpEd = false;
        }
    }
}
