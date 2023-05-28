using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returntomenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // After 10 seconds, return to the main menu
        StartCoroutine(return_to_menu());
    }

    IEnumerator return_to_menu()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("main menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
