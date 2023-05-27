using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    Rigidbody2D rb;
    CircleCollider2D cc;

    [SerializeField] private Animator an;
    [SerializeField] private float acceleration = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float scale = 1f;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
        transform.localScale = new Vector3(scale, scale, scale);
    }

    // Update is called once per frame
    void Update()
    {
        move();

        RaycastHit2D hit = Physics2D.Raycast(rb.position - new Vector2(0, 0.5f), Vector2.down, 1f, LayerMask.GetMask("tilemap"));

        if (hit.distance < cc.radius - 0.1f && hit.collider != null)
        {
            isGrounded = true;
        }
        else isGrounded = false;


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump();
        }
    }

    void move()
    {
        float x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(x * acceleration, rb.velocity.y);
    }

    void jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
