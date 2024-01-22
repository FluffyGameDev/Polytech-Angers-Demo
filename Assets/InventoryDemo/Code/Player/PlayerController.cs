using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private static readonly string k_MoveAction = "Move";

    [SerializeField]
    private InputActionAsset m_PlayerInputs;
    [SerializeField]
    private CharacterController m_CharacterController;
    [SerializeField]
    private float m_Speed;

    private InputAction m_MoveAction;

    private void Start()
    {
        m_MoveAction = m_PlayerInputs[k_MoveAction];
    }

    private void Update()
    {
        Vector2 inputDirection = m_MoveAction.ReadValue<Vector2>();
        Vector3 movement = new Vector3(inputDirection.x, 0.0f, inputDirection.y).normalized * m_Speed;
        m_CharacterController.Move(movement);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //TODO
        }
    }
}
