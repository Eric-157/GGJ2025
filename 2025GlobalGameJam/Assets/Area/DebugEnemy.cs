using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 1;

    void Start()
    {
        Destroy(this.gameObject, 5);
    }

    void Update()
    {
        transform.position += speed * Time.deltaTime * transform.up;
    }
}
