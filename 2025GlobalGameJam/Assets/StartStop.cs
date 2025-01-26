using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStop : MonoBehaviour
{
    public bool gameStart = false;
    public bool gameStop = false;
    private float xAxis;
    private float yAxis;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");
        if (xAxis > 0 || yAxis > 0)
        {
            gameStart = true;
        }
        if (playerController.health <= 0)
        {
            gameStop = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
