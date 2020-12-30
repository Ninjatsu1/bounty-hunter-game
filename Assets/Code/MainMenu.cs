using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Play game
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Quit game
    public void QuitGame()
    {
       Debug.Log("Quitting..."); 
       Application.Quit();
    }
       
    
}
