using PolytechAngers.Interaction;
using UnityEngine;

namespace PolytechAngers.Inventory
{
    public class ItemPickUpInteraction : Interactable
    {
        [SerializeField]
        private InventoryItemData m_ItemData;

        public override bool CanInteract()
        {
            return PlayerInventoryService.PlayerInventory.CanAddItem(m_ItemData);
        }

        public override void Interact()
        {
            PlayerInventoryService.PlayerInventory.AddItem(m_ItemData, 1);
            Destroy(gameObject);
        }
    }
}
