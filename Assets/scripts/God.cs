using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
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
        if (player_distance < 5)
        {
            trigger_escape();
        }
    }

    // Trigger escape
    private void trigger_escape()
    {
        UI_manager.instance.objective_text.text = "Escape?";
        UI_manager.instance.red_border.SetActive(true);
    }
}
