using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public AreaManager areaManager;

    public List<SpawnSlot> spawnSlots = new();

    private List<float> timers = new();

    public void OnAreaChange()
    {
        // Ensure timers has the same length as the current encounter table
        timers.Clear();
        for (int i = 0; i < areaManager.Current().encounters.Count; i++)
        {
            timers.Add(0);
        }
    }

    public void Update()
    {
        // For every encounter table and timer
        for (int i = 0; i < timers.Count; i++)
        {
            timers[i] += Time.deltaTime;

            var encounter = areaManager.Current().encounters[i];

            // If interval hasn't passed, skip the rest of this code
            if (timers[i] < encounter.interval) continue;

            timers[i] = 0;

            var prefab = encounter.prefabs.Random();
            var slot = spawnSlots[encounter.slots.Random()];

            var spawned = Instantiate(prefab);

            // We don't simply set parent because we don't want to copy scale
            spawned.transform.SetPositionAndRotation(slot.transform.position, slot.transform.rotation);

            // Adjust spawn edge so big objects don't go outside of the spawn area
            var edge = slot.transform.localScale.x / 2 - spawned.transform.localScale.x / 2;

            // Adjust position to random spot within spawn area
            spawned.transform.position += spawned.transform.right * Random.Range(-edge, edge);
        }
    }
}
