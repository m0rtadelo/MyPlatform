using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeptimonstruoController : MonoBehaviour
{
    [SerializeField]
    private float direction = -1;
    [SerializeField]
    private float Speed = 4;
    [SerializeField]
    private float Velocity = 2;
    [SerializeField]
    GameObject prefab;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private GameObject Game;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag.Equals("MonsterLimit")) {
            direction = direction * -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("MonsterKiller")) {
            Game.GetComponent<GameController>().AddPoints(10);
            other.GetComponentInParent<PlayerController>().Bounce();
            Instantiate(prefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Game = GameObject.Find("Game");
    }
    private void Update()
    {
        Vector2 newVelocity = rb.velocity;
        if (direction > 0) {
            newVelocity.x = Velocity;
            //rb.AddForce(Vector2.right * Speed * Time.deltaTime, ForceMode2D.Impulse);
            rb.velocity = newVelocity;
            sr.flipX = false;
        } else if (direction < 0) {
            newVelocity.x = Velocity * -1;
            //rb.AddForce(Vector2.left * Speed * Time.deltaTime, ForceMode2D.Impulse);
            rb.velocity = newVelocity;
            sr.flipX = true;
        }
    }
}
