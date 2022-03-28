using UnityEngine;

public class GroundedController : MonoBehaviour
{
    private PlayerController pc;
    private BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponentInParent<PlayerController>();
        bc = GetComponent<BoxCollider2D>();
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        pc.Grounded = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        pc.Grounded = false;
    }

    private void OnTriggerStay2D(Collider2D other) {
        pc.Grounded = true;
    }

    
}
