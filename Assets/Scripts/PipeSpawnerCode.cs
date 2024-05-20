using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerCode : MonoBehaviour
{
    // Step 1: Set up Variables
    public GameObject TopPipePrefab;
    public GameObject BottomPipePrefab;

    private float timer;
    private float PipeSpawnY;

    public GameObject Button;

    // Step 2: Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Step 3: Spawn Pipe every 2 seconds if the game has started
    private void Update()
    {
        if (Button.GetComponent<StartButtonCode>().GameStarted == true)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                SpawnPipe();
                timer = 0;
            }
        }
    }

    // Step 4: Spawn Pipe
    public void SpawnPipe()
    {
        // Randomize Y Position of Pipes
        PipeSpawnY = Random.Range(-2.5f, 2.5f);

        // Instantiate (Create a Clone for) Top Pipe and Bottom Pipe 
        Instantiate(TopPipePrefab, new Vector3(10, PipeSpawnY + 5.5f, 0), Quaternion.identity);
        Instantiate(BottomPipePrefab, new Vector3(10, PipeSpawnY - 5.5f, 0), Quaternion.identity);
    }
}
