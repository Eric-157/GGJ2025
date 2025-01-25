using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AreaDef : ScriptableObject
{
    public int repeat;

    public Sprite background;

    public List<Encounter> encounters = new();

    [System.Serializable]
    public class Encounter
    {
        public float interval;

        public List<int> slots = new();

        public List<GameObject> prefabs = new();
    }
}

static class ListExtention
{
    public static T Random<T>(this List<T> values)
    {
        return values[UnityEngine.Random.Range(0, values.Count)];
    }
}
