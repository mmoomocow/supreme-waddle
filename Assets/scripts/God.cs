using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private bool triggered = false;
    private bool triggered_closer = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float player_distance = Vector3.Distance(player.transform.position, transform.position); 
        // Debug.Log(player_distance);


        if (player_distance < 15 && triggered_closer == false)
        {
            UI_manager.instance.message_text.gameObject.SetActive(true);
            UI_manager.instance.message_text.text = "Come Closer...";
            StartCoroutine(close_message());
            Debug.Log("Come Closer...");
            triggered_closer = true;
        }
        else if (player_distance < 7 && triggered == false)
        {
            trigger_escape_section();
            triggered = true;
        }
    }

    public void trigger_escape_section()
    {
        Game_Manager.instance.freeze_player();

        Game_Manager.instance.display_message();

        // Show the red border
        UI_manager.instance.red_border.SetActive(true);
        // Set the objective text to Escape!
        UI_manager.instance.objective_text.text = "Escape!";
        
    }

    private IEnumerator close_message()
    {
        yield return new WaitForSeconds(3);
        UI_manager.instance.message_text.gameObject.SetActive(false);
    }
}
