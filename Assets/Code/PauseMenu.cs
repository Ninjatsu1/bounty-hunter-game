using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    private InputManager inputManager;

    private void Start()
    {
        inputManager = InputManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputManager.OpenMenu())
        {
            Debug.Log("Open menu");
            
        }
    }
}
