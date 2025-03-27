using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Collider2D playerCollider;
    private Rigidbody2D rb;
    private bool isDead = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");

        if (collision.CompareTag("Enemy") && !isDead)
        {
            Debug.Log("Player Died");
            Destroy(gameObject);
        }
    }

    
}
