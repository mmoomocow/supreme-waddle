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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
}
