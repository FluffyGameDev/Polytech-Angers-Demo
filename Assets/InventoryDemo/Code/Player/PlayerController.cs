using PolytechAngers.Inventory;
using PolytechAngers.UI;
using UnityEngine;
using UnityEngine.InputSystem;


namespace PolytechAngers.Player
{
    public class PlayerController : MonoBehaviour
    {
        private static readonly string k_MoveAction = "Move";

        [SerializeField]
        private InputActionAsset m_PlayerInputs;
        [SerializeField]
        private CharacterController m_CharacterController;
        [SerializeField]
        private InventoryHolder m_InventoryHolder;
        [SerializeField]
        private InventoryViewModel m_InventoryViewModel;
        [SerializeField]
        private ShowInventoryEvent m_ShowInventoryEvent;
        [SerializeField]
        private float m_Speed;

        private InputAction m_MoveAction;

        private void Start()
        {
            m_MoveAction = m_PlayerInputs[k_MoveAction];
            m_InventoryViewModel.BindInventory(m_InventoryHolder.Inventory);
            m_InventoryViewModel.OwnerName = m_InventoryHolder.HolderName;
            m_InventoryViewModel.ShowInventory = false;
        }

        private void Update()
        {
            Vector2 inputDirection = m_MoveAction.ReadValue<Vector2>();
            Vector3 movement = new Vector3(inputDirection.x, 0.0f, inputDirection.y) * m_Speed;
            m_CharacterController.Move(movement);
        }

        public void OnToggleInventory(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                m_ShowInventoryEvent.TriggerEvent(m_InventoryHolder);
                m_InventoryViewModel.ShowInventory = !m_InventoryViewModel.ShowInventory;
            }
        }
    }
}
