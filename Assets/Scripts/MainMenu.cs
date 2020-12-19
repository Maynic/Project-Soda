using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
// using UnityEngine.UI;

public class MainMenu : MonoBehaviour
// public class SC_MainMenu : MonoBehaviour
{
    public GameObject thisMainMenu;
    public GameObject OptionMenu;
    public UnityEngine.UI.Button mainB ;
    public UnityEngine.UI.Button optiB ;


    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();

    }

    void Update(){
        // UnityEngine.UI.Button s = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        // s.Select();
    }

    public void PlayNowButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu_ChooseLevel");
    }

    public void OptionButton()
    {
        // Show Credits Menu
        thisMainMenu.SetActive(false);
        OptionMenu.SetActive(true);
        optiB.Select();

    }

    public void MainMenuButton()
    {
        // Show Main Menu
        thisMainMenu.SetActive(true);
        OptionMenu.SetActive(false);
        mainB.Select();

    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}