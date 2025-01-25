using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EntityController : MonoBehaviour
{
    public EntityBehavior entityBehavior;
    public string goodTag;
    public float killY;

    private Rigidbody2D rigidbody2d;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D entityCollider;
    private float speed;
    private float gravityScale;
    private float colliderX;
    private float colliderY;
    private Sprite entitySprite;
    private int moveDir;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        entityCollider = GetComponent<BoxCollider2D>();

        speed = entityBehavior.SPEED;
        gravityScale = entityBehavior.GRAVITY_SCALE;
        colliderX = entityBehavior.COLLIDER_X;
        colliderY = entityBehavior.COLLIDER_Y;
        entitySprite = entityBehavior.ENTITY_SPRITE;
        goodTag = entityBehavior.TAG;
        moveDir = entityBehavior.isFlipped;

        entityCollider.size = new Vector2(colliderX,colliderY);
        spriteRenderer.sprite = entitySprite;
        rigidbody2d.gravityScale = gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= killY){
            Destroy(gameObject);
        }
    }

    void FixedUpdate(){
        rigidbody2d.velocity = new Vector2(speed * moveDir, rigidbody2d.velocity.y);
    }
}
