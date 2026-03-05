using UnityEngine;
using UnityEngine.InputSystem;

public class Target : MonoBehaviour
{
    public Player targettedPlayer;
    public bool isMouseOverPlayer;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        targettedPlayer = GetComponentInParent<Player>();
        isMouseOverPlayer = true;
    }

    private void OnMouseExit()
    {
        isMouseOverPlayer = false;
    }

    public void TargetPlayer(InputAction.CallbackContext context)
    {
        if (context.performed && isMouseOverPlayer)
        { 
            targettedPlayer.isBeingTargetted = true;
        }
    }
}
