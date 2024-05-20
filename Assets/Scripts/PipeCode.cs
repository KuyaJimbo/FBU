using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCode : MonoBehaviour
{
    // Step 1: Set up Variables
    private float PipeSpeed;

    // Step 2: Start is called before the first frame update
    void Start()
    {
        PipeSpeed = 3f;
    }

    // Step 3: Update is called once per frame
    void Update()
    {
        MoveLeft();
        OffScreenDestroy();
    }

    // Step 4: Move the pipe to the left
    void MoveLeft()
    {
        transform.position += new Vector3(-PipeSpeed * Time.deltaTime, 0, 0);
    }

    // Step 5: If the pipe is out of the screen on left side, destroy it
    void OffScreenDestroy()
    {
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}

// Step 7: Attach this script to the Pipe Prefabs