using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseManager : MonoBehaviour
{

    public InputManager inputManager;
    public bool MenuIsOpen = false;
    public GameObject PauseMenuGameObject;
    private void Start()
    {
        inputManager = InputManager.Instance;
    }

    private void Update()
    {
        if (inputManager.DisplayMenu)
        {
            OpenMenu();
        }
        if (inputManager.DisplayMenu == false)
        {
            CloseMenu();
            PauseMenuGameObject.SetActive(false);
        }
    }

    //Stop game time
    public void OpenMenu()
    {
        if (inputManager.OpenMenu())
        {
            //TO DO: fix camera rotation and game should not be paused
            Time.timeScale = 0;
            inputManager.SwitchToUIActionMap();
            MenuIsOpen = true;
            PauseMenuGameObject.SetActive(true);
        }
    }

    //Toggle esc
    public void CloseMenu()
    {
        if (inputManager.CloseMenu())
        {
            Time.timeScale = 1;
            MenuIsOpen = false;
            PauseMenuGameObject.SetActive(false);
            inputManager.SwitchToPlayerActionMap();
        }
    }

    //Resume button
    public void OnResumeButton()
    {
        MenuIsOpen = false;
        PauseMenuGameObject.SetActive(false);
        inputManager.SwitchToPlayerActionMap();
    }

    //Open main menu
    public void OnMainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //Quit game
    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}