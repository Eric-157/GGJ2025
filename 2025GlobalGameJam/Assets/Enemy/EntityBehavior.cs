using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Entity", menuName = "Entity")]
public class EntityBehavior : ScriptableObject
{
    public float SPEED;
    public float GRAVITY_SCALE;
    //public float COLLIDER_X;
    //public float COLLIDER_Y;
    //public Sprite ENTITY_SPRITE;
    public string TAG;
    public char COLOR;
}
