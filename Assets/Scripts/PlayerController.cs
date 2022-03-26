using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float Velocity = 6;
    [SerializeField]
    private float Speed = 20;
    [SerializeField]
    private float JumpForce = 1000;
    [SerializeField]
    private float MaxVelocityX = 6;
    [SerializeField]
    private GameObject deathParticles;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;
    private bool Grounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        bool jump = Input.GetButtonDown("Jump");
        float movementY = rb.velocity.y;
        if (movementY > 0.2 || movementY < -0.2) {
            animator.SetFloat("Movement", 0);
        } else {    
            animator.SetFloat("Movement", Mathf.Abs(rb.velocity.x));
        }
        animator.SetFloat("MovementY", movementY);
        Vector2 newVelocity = rb.velocity;
        if (x > 0.1f) {
            // rb.AddForce(Vector2.right * Speed, ForceMode2D.Impulse);
            newVelocity.x = Velocity;
            rb.velocity = newVelocity;
            sr.flipX = false;
        } else if (x < -0.1f) {
            // rb.AddForce(Vector2.left * Speed, ForceMode2D.Impulse);
            newVelocity.x = Velocity * -1;
            rb.velocity = newVelocity;
            sr.flipX = true;
        } else {
            rb.AddForce(Vector2.left * rb.velocity.x, ForceMode2D.Impulse);
        }
        if (jump) {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        } 
    }

    public void Die() {
        Instantiate(deathParticles, this.transform.position, Quaternion.identity);
        // deathParticles.GetComponent<ParticleSystem>().Play();
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Enter " + other.gameObject.name);
        Grounded = true;
    }

    private void OnCollisionExit2D(Collision2D other) {
        Debug.Log("Exit " + other.gameObject.name);
        Grounded = false;
    }
}
