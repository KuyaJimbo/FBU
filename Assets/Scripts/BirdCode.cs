using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCode : MonoBehaviour
{
    // Step 1: Set up Variables
    private float YSpeed;
    private float YAcceleration;
    public bool alive;

    // Step 2: Start is called before the first frame update
    void Start()
    {
        YSpeed = 0;
        YAcceleration = -0.1f;
        alive = true;
    }

    // Step 3: Update is called once per frame
    void Update()
    {
        if (alive) {
            Flap();
        }

        Fly();
        ControlSpeed();
        SimpleRotate();
    }

    // Step 4: Flap the bird
    void Flap()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Make the bird fly upwards
            YSpeed = 10; 
        }
    }

    // Step 5: Let the bird fly
    void Fly()
    {
        // Move the bird up or down based on YSpeed
        transform.position += new Vector3(0, YSpeed * Time.deltaTime, 0); 
    }

    // Step 6: Control the speed of the bird
    void ControlSpeed()
    {
        // Apply gravity to the bird
        YSpeed += YAcceleration;
        // Limit the falling speed of the bird (terminal velocity)
        if (YSpeed < -5)
        {
            YSpeed = -5;
        }
    }

    // Step 7: Rotate the bird
    void SimpleRotate()
    {
        if (YSpeed > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, -45);
        }
    }

    void CoolRotate()
    {
        // if the speed is greater than 0, then rotate the bird upwards until max at 45 degrees
        if (YSpeed > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, 45, YSpeed / 10));
        }
        // if the speed is less than 0, then rotate the bird downwards until max at -45 degrees
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, -90, -YSpeed / 10));
        }
    }

    // Step 8: Check if the bird hits the pipe
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pipe")
        {
            alive = false;
        }
    }

    // Step 9: Check if the bird is out of the screen
    private void OnBecameInvisible() {
        alive = false;
    }
}
