using UnityEngine;
using UnityEngine.Localization;

namespace PolytechAngers.Inventory
{
    public class InventoryHolder : MonoBehaviour
    {
        [SerializeField]
        private LocalizedString m_HolderName;
        [SerializeField]
        private InventoryData m_DefaultInventoryData;

        public Inventory Inventory => m_Inventory;
        public string HolderName => m_HolderName.GetLocalizedString();

        private void Awake()
        {
            m_Inventory = new(m_DefaultInventoryData.DefaultSlots.Count);
            foreach (var slot in m_DefaultInventoryData.DefaultSlots)
            {
                m_Inventory.AddItem(slot.ItemData, slot.Quantity);
            }
        }

        private Inventory m_Inventory;
    }
}
