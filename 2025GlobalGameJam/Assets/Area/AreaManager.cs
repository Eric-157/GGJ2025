using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public SpawnManager spawnManager;
    public Background background;
    public AudioSource audioSource;
    public StartStop gameManager;

    public List<AreaDef> areas = new();

    private int currentArea = 0;

    private int currentRepeat = 0;


    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spawnManager.OnAreaChange();
        background.OnAreaChange();
    }

    public void Progress()
    {
        currentRepeat++;

        // If we're iterating the same area, nothing left to do
        if (currentRepeat < Current().repeat) return;

        // If this is the final area, just loop indefinetly
        if (currentArea == areas.Count - 1) return;

        currentRepeat = 0;
        currentArea++;
        spawnManager.OnAreaChange();
        background.OnAreaChange();
    }

    public AreaDef Current()
    {
        return areas[currentArea];
    }

    public AreaDef Upcomming()
    {
        audioSource.clip = areas[currentArea].music;
        audioSource.Play();
        // If this is the final area, just loop indefinetly
        if (currentArea == areas.Count - 1) return Current();

        // Final iteration, return next area
        if (currentRepeat == Current().repeat) return areas[currentArea + 1];

        // We still have iterations, return current
        return Current();
    }

    void Update()
    {
        if (gameManager.gameStop)
        {
            spawnManager.isRunning = false;
            background.isRunning = false;
        }
    }
}
