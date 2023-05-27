using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float cast_radius = 3f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Circle Cast
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, cast_radius, Vector2.zero, cast_radius + 2f, LayerMask.GetMask("Player"));
        Debug.DrawRay(transform.position, Vector2.left, Color.red, 10f);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject == player)
            {
                // Player is in range
            }
        }
    }
}
