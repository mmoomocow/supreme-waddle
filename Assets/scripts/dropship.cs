using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropship : MonoBehaviour
{
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float player_distance = Vector3.Distance(player.transform.position, transform.position);
        // Debug.Log(player_distance);
        if (God.instance.triggered && player_distance < 7)
        {
            Game_Manager.instance.saved();
        }
    }


}
