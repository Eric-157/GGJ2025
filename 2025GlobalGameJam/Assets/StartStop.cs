using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartStop : MonoBehaviour
{
    public bool gameStart = false;
    public bool gameStop = false;
    private float xAxis;
    private float yAxis;
    public PlayerController playerController;
    public GameObject start;
    public GameObject stop;

    // Start is called before the first frame update
    void Start()
    {
        playerController.startScoring = false;
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");
        if (xAxis > 0 || yAxis > 0)
        {
            gameStart = true;
            playerController.startScoring = true;
        }
        if (!gameStart)
        {
            start.SetActive(true);
        }
        else { start.SetActive(false); }
        if (playerController.health <= 0)
        {
            gameStop = true;
            playerController.gameObject.SetActive(false);
            stop.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
