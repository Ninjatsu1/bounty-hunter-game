using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public PlayerInput playerInput;
    private PlayerControls playerControls;
    public bool DisplayMenu = false;
    //Get this befote start
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        playerControls = new PlayerControls();
        playerInput = GetComponent<PlayerInput>();
    }
    private void Start()
    {
        playerControls.UI.Disable();
    }

    //Enable Controls
    private void OnEnable()
    {
        playerControls.Enable();
    }
    //Disable controls
    private void OnDisable()
    {
        playerControls.Disable();
    }

    //Get movement
    public Vector2 GetPlayerMovement()
    {
        return playerControls.Player.Movement.ReadValue<Vector2>();
    }

    //Get mouse movement
    public Vector2 GetMouseDelta()
    {
        return playerControls.Player.Look.ReadValue<Vector2>();
    }

    //Player jump
    public bool PlayerJumped()
    {
        return playerControls.Player.Jump.triggered;
    }

    //Interact with object
    public bool Interact()
    {
        return playerControls.Player.Interact.triggered;
    }

    //Player sprint start
    public bool PlayerSprint()
    {
        return playerControls.Player.SprintStart.triggered;
    }

    //Player sprint finish
    public bool PlayerSprintFinish()
    {
        return playerControls.Player.SprintFinish.triggered;
    }

    //Open menu
    public bool OpenMenu()
    {
        DisplayMenu = true;
        
        return playerControls.Player.OpenMenu.triggered;
        
    }

    //Change to UI action map

    public void SwitchToUIActionMap()
    {
        //DisplayMenu = true;
        playerControls.Player.Disable();
        playerControls.UI.Enable();
        playerInput.SwitchCurrentActionMap("UI");
        Debug.Log("Current Action Map: " + playerInput.currentActionMap.name);
    }

    //Switch back to player map
    public void SwitchToPlayerActionMap()
    {
        DisplayMenu = false;
        playerControls.UI.Disable();
        playerControls.Player.Enable();
        playerInput.SwitchCurrentActionMap("Player");
        Debug.Log("Current Action Map: " + playerInput.currentActionMap.name);
    }

    //Close menu
    public bool CloseMenu()
    {
        return playerControls.UI.CloseMenu.triggered;
    }
}