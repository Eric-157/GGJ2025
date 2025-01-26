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
    private SpriteRenderer spriteRenderer;
    private float xAxis;
    private float yAxis;
    public bool canBeDamaged = true;
    public int r, b, g;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        health = 1;
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(xAxis * speed, yAxis * speed);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        EntityController entityController = collider.gameObject.GetComponent<EntityController>();
        //Debug.Log(entityController.goodTag);
        if (entityController.goodTag == "Pickup")
        {
            Destroy(collider.gameObject);
            if (health < maxHealth)
            {
                health++;

            }
        }
        if (entityController.goodTag == "Enemy" && canBeDamaged)
        {
            health--;
            canBeDamaged = false;
            StartCoroutine("DamageInvuln");
        }
        float bubbleSize = 0.25f + (health / 10);
        boxCollider2D.size = new Vector2(bubbleSize / 2, bubbleSize / 2);
        spriteRenderer.transform.localScale = new Vector3(bubbleSize, bubbleSize, bubbleSize);
    }

    IEnumerator DamageInvuln()
    {
        yield return new WaitForSeconds(0.5f);
        canBeDamaged = true;
    }
}
