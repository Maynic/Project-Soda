using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Win : MonoBehaviour
{
    // public GameObject thisMainMenu;
    public GameObject levelManager;
    public UnityEngine.UI.Button mainB ;
    // public UnityEngine.UI.Button optiB ;


    // Start is called before the first frame update
    void Start()
    {
        // MainMenuButton();
        mainB.Select();
        levelManager =  GameObject.FindGameObjectWithTag("LevelManager");

    }

    public void Retry()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        // levelManager.levelN = 1;
        string ls = levelManager.GetComponent<LevelManager>().levelN.ToString();
        string toLoad = "Level"+ls;

        // UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        UnityEngine.SceneManagement.SceneManager.LoadScene(toLoad);
    }
    public void NextLevel()
    {
        int t = levelManager.GetComponent<LevelManager>().levelN + 1;
        string ls = t.ToString();
        string toLoad = "Level"+ls;

        // UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        UnityEngine.SceneManagement.SceneManager.LoadScene(toLoad);
    }
    // public void Button_3()
    // {
    //     levelManager.GetComponent<LevelManager>().levelN = 3;
    //     UnityEngine.SceneManagement.SceneManager.LoadScene("Level3");
    // }
    // public void Button_4()
    // {
    //     levelManager.GetComponent<LevelManager>().levelN = 4;
    //     UnityEngine.SceneManagement.SceneManager.LoadScene("Level4");
    // }
    // public void OptionButton()
    // {
    //     // Show Credits Menu
    //     thisMainMenu.SetActive(false);
    //     OptionMenu.SetActive(true);
    //     optiB.Select();

    // }

    // public void MainMenuButton()
    // {
    //     // Show Main Menu
    //     thisMainMenu.SetActive(true);
    //     OptionMenu.SetActive(false);
    //     mainB.Select();

    // }

    public void BackButton()
    {
        // Quit Game
        Destroy(levelManager);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu_Main");
    }
}