using PolytechAngers.Interaction;
using PolytechAngers.Inventory;
using PolytechAngers.UI;
using UnityEngine;
using UnityEngine.Localization;

namespace PolytechAngers.AI
{
    public class MerchantInteraction : Interactable
    {
        [SerializeField]
        private InventoryHolder m_MerchantInventory;
        [SerializeField]
        private InventoryViewModel m_InventoryViewModel;
        [SerializeField]
        private ShowInventoryEvent m_ShowInventoryEvent;

        public override bool CanInteract()
        {
            return true;
        }

        public override void Interact()
        {
            m_ShowInventoryEvent.TriggerEvent(m_MerchantInventory);

            m_InventoryViewModel.ShowInventory = !m_InventoryViewModel.ShowInventory;
            if (m_InventoryViewModel.ShowInventory)
            {
                m_InventoryViewModel.OwnerName = m_MerchantInventory.HolderName;
                m_InventoryViewModel.BindInventory(m_MerchantInventory.Inventory);
            }
        }

        private void Awake()
        {
            m_InventoryViewModel.ShowInventory = false;
        }
    }
}
