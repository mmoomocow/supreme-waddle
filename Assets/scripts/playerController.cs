using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    Rigidbody2D rb;
    CircleCollider2D cc;

    [SerializeField] private Animator an;
    [SerializeField] private float acceleration = 5f;
    [SerializeField] private float max_speed = 10f;
    [SerializeField] private float stationary_friction = 0.8f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float x_bounds = 0.5f;
    [SerializeField] private float y_bounds = 0.5f;
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

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("jump 1");
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
        Debug.Log("jump 2");
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
