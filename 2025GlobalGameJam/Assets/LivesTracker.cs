using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesTracker : MonoBehaviour
{
    public GameObject[] playerObj;
    public PlayerController playerController;
    public List<GameObject> playerLives = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectsWithTag("Player");
        playerController = playerObj[0].GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        int j = 0;
        foreach (var GameObject in playerLives)
        {
            playerLives[j].SetActive(false);
            j++;
        }
        for (int i = 0; i < playerController.health; i++)
        {
            playerLives[i].SetActive(true);
        }
    }
}
