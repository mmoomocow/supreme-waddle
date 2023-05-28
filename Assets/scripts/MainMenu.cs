using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Real Game");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Credits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
    }

    public void Back()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
	}
}
