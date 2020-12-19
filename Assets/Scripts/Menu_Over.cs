using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Over : MonoBehaviour
{
    // public GameObject thisMainMenu;
    public GameObject levelManager;
    public GameObject dc;
    // public UnityEngine.UI.Button mainB ;
    // public UnityEngine.UI.Button optiB ;


    // Start is called before the first frame update
    void Start()
    {
        // MainMenuButton();
        // mainB.Select();
        levelManager =  GameObject.FindGameObjectWithTag("LevelManager");
        dc =  GameObject.FindGameObjectWithTag("DieCar");

    }

    void Update(){
        if(levelManager.GetComponent<LevelManager>().resp == -5){
            dc.transform.Find("T").gameObject.SetActive(false);
            dc.transform.Find("TCar").gameObject.SetActive(true);
        }
    }

    public void Retry()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        // levelManager.levelN = 1;
        string ls = levelManager.GetComponent<LevelManager>().levelN.ToString();
        string toLoad = "Level "+ls;

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