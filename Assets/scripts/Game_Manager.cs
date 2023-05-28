using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;
    public GameObject player;
    public GameObject god;
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
}
