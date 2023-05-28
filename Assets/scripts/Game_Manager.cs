using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;
    public GameObject player;
    public GameObject god;
    public bool gameover = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("More than one Game_Manager in the scene! Destroying self!");
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Additive scene loading of UI scene
        SceneManager.LoadScene("UI scene", LoadSceneMode.Additive);
        Debug.Log("UI scene loaded");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void freeze_player()
    {
        player.GetComponent<playerController>().frozen = true;
        // Remove any velocity
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void unfreeze_player()
    {
        player.GetComponent<playerController>().frozen = false;
    }

    public void display_message()
    {
        SceneManager.LoadScene("angry god", LoadSceneMode.Additive);
        StartCoroutine(close_message());
    }

    public void timer_ran_out()
    {
        stranded();
    }

    IEnumerator close_message()
    {
        yield return new WaitForSeconds(5);
        SceneManager.UnloadSceneAsync("angry god");
        unfreeze_player();
        StartCoroutine(UI_manager.instance.start_timer(90));
    }

    public void saved()
    {
        if (gameover == false)
        {
            SceneManager.LoadScene("win ship", LoadSceneMode.Single);
            gameover = true;
        }
    }

    public void stranded()
    {
        if (gameover == false)
        {
            SceneManager.LoadScene("win stranded", LoadSceneMode.Single);
            gameover = true;
        }
    }
}
