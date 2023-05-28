using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    Rigidbody2D rb;
    CircleCollider2D cc;

    [SerializeField] private float acceleration = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float scale = 1f;
    private bool isGrounded = true;
    public bool frozen = false;

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
        if (frozen) return;
        move();

        // 3 raycasts to check if the player is grounded
        float raycastDistance = cc.bounds.extents.y + 0.5f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, 1 << LayerMask.NameToLayer("tilemap"));
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position + new Vector3(cc.bounds.extents.x -0.4f, 0, 0), Vector2.down, raycastDistance, 1 << LayerMask.NameToLayer("tilemap"));
        RaycastHit2D hit3 = Physics2D.Raycast(transform.position - new Vector3(cc.bounds.extents.x -0.4f, 0, 0), Vector2.down, raycastDistance, 1 << LayerMask.NameToLayer("tilemap"));
        // Debug.DrawRay(transform.position, Vector2.down * raycastDistance, Color.red);
        // Debug.DrawRay(transform.position + new Vector3(cc.bounds.extents.x, 0, 0), Vector2.down * raycastDistance, Color.red);
        // Debug.DrawRay(transform.position - new Vector3(cc.bounds.extents.x, 0, 0), Vector2.down * raycastDistance, Color.red);

        // Debug.Log(hit.collider);
        // Debug.Log(hit2.collider);
        // Debug.Log(hit3.collider);

        if (hit.collider != null || hit2.collider != null || hit3.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }


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
