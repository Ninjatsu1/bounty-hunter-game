using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private PlayerControls playerControls;
    
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

    //Player sprint
    public bool PlayerSprint()
    {
        return playerControls.Player.SprintStart.triggered;
    }

    public bool PlayerSprintFinish()
    {
        return playerControls.Player.SprintFinish.triggered;
    }
}
