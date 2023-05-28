using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_manager : MonoBehaviour
{

    public GameObject red_border;
    public static UI_manager instance;

    public TMPro.TextMeshProUGUI objective_text;
    public TMPro.TextMeshProUGUI message_text;
    public TMPro.TextMeshProUGUI timer_text;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("More than one UI_manager in the scene! Destroying self!");
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        red_border.SetActive(false);
        objective_text.text = "Explore!";
        // Hide the message text
        message_text.gameObject.SetActive(false);
        // Hide the timer text
        timer_text.gameObject.SetActive(false);
    }


    // 60 second timer
    public IEnumerator start_timer(float time)
    {
        timer_text.gameObject.SetActive(true);
        while (time > 0)
        {
            time -= Time.deltaTime;
            Debug.Log(time);
            timer_text.text = time.ToString("F0");
            yield return null;
        }
        // Whem the timer runs out, call the timer_ran_out function in Game_Manager
        Game_Manager.instance.timer_ran_out();
    }
}
