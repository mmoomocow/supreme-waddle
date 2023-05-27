using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    Rigidbody2D rb;
    BoxCollider2D bc;

    [SerializeField] private Animator an;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float x_bounds = 0.5f;
    [SerializeField] private float y_bounds = 0.5f;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
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
        
        if (x > 0 && transform.position.x < x_bounds)
        {
            transform.position += new Vector3(x * speed * Time.deltaTime, 0, 0);
        }
        else if (x < 0 && transform.position.x > -x_bounds)
        {
            transform.position += new Vector3(x * speed * Time.deltaTime, 0, 0);
        }

        // flip left/right
        if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
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
