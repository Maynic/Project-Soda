using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Win : MonoBehaviour
{
    // public GameObject thisMainMenu;
    public GameObject levelManager;
    public GameObject t2;
    // public UnityEngine.UI.Button mainB ;
    // public UnityEngine.UI.Button optiB ;


    // Start is called before the first frame update
    void Start()
    {
        // MainMenuButton();
        // mainB.Select();
        levelManager =  GameObject.FindGameObjectWithTag("LevelManager");
        t2 =  GameObject.FindGameObjectWithTag("Task2");

    }

    void Update(){
        if(levelManager.GetComponent<LevelManager>().resp > 9){t2.SetActive(true);}
        else{t2.SetActive(false);}
    }

    public void Retry()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        // levelManager.levelN = 1;
        string ls = levelManager.GetComponent<LevelManager>().levelN.ToString();
        string toLoad = "Level "+ls;

        // UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(toLoad);
    }
    public void NextLevel()
    {
        int t = levelManager.GetComponent<LevelManager>().levelN + 1;
        string ls = t.ToString();
        string toLoad = "Leve l"+ls;

        // UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        UnityEngine.SceneManagement.SceneManager.LoadScene(toLoad);
    }

    public void BackButton()
    {
        // Quit Game
        Destroy(levelManager);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu_Main");
    }
}