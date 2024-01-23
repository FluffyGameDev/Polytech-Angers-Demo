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
        private LocalizedString m_MerchantName;
        [SerializeField]
        private InventoryHolder m_MerchantInventory;
        [SerializeField]
        private InventoryViewModel m_InventoryViewModel;

        public override bool CanInteract()
        {
            return true;
        }

        public override void Interact()
        {
            m_InventoryViewModel.ShowInventory = !m_InventoryViewModel.ShowInventory;
            if (m_InventoryViewModel.ShowInventory)
            {
                m_InventoryViewModel.OwnerName = m_MerchantName.GetLocalizedString();
                m_InventoryViewModel.BindInventory(m_MerchantInventory.Inventory);
            }
        }
    }
}
