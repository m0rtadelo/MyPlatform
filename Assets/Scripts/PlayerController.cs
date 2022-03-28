using System.Collections;
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
    private SoundController sc;
    private GameController gc;
    public bool Grounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        GameObject Game = GameObject.Find("Game");
        sc = Game.GetComponent<SoundController>();
        gc = Game.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        // bool right = Input.GetButtonDown(KeyCode.Joystick1Button0);
        // bool left = Input.GetKeyDown(KeyCode.A);
        // if (left) 
        //     x = -1;
        // if (right)
        //     x = 1;
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
            rb.AddForce(Vector2.left * (rb.velocity.x * 5), ForceMode2D.Impulse);
        }
        if (jump && Grounded) {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        } 
    }

    /// <summary>
    /// Add bounce to player
    /// </summary>
    public void Bounce() {
        rb.AddForce(Vector2.up * 300, ForceMode2D.Impulse);
    }
    public void Die() {
        sc.PlayPlayerDeath(this.transform.position);
        Instantiate(deathParticles, this.transform.position, Quaternion.identity);
        StartCoroutine(Wait3());
        sr.enabled = false;
    }

  IEnumerator Wait3()
  {
    yield return new WaitForSeconds(3);
    gc.RestartLevel();
  }

}
