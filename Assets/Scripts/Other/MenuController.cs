using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Button PlayButton;
    public Button QuitButton;

    public void PlayGame()
    {
        SceneManager.LoadScene("LevelArea");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
