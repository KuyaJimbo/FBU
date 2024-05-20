using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonCode : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject Bird;

    public bool GameStarted;

    // Start is called before the first frame update
    void Start()
    {
        GameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        StartButton.SetActive(false);
        // Create a bird
        Instantiate(Bird, new Vector3(0, 0, 0), Quaternion.identity);
        GameStarted = true;
    }
}
