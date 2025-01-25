using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float health;
    public float maxHealth;
    public float gravity;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;
    private float xAxis = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(xAxis * speed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collider){
        EntityController entityController = collider.gameObject.GetComponent<EntityController>();
        Debug.Log(entityController.goodTag);
        if (entityController.goodTag == "Pickup"){
            Destroy(collider.gameObject);
        }
    }
}
