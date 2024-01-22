using System;
using UnityEngine;

namespace PolytechAngers.Inventory
{
    public class InventoryHolder : MonoBehaviour
    {
        [SerializeField]
        private InventoryData m_DefaultInventoryData;

        public Inventory Inventory => m_Inventory;

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
