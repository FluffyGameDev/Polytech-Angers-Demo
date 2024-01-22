using System;
using System.Collections.Generic;
using UnityEngine;

namespace PolytechAngers.Inventory
{
    [Serializable]
    public struct InventorySlotData
    {
        [SerializeField]
        private InventoryItemData m_ItemData;
        [SerializeField]
        private int m_Quantity;

        public InventoryItemData ItemData => m_ItemData;
        public int Quantity => m_Quantity;
    }

    [CreateAssetMenu(menuName = "Polytech Angers/Inventory/Inventory Data")]
    public class InventoryData : ScriptableObject
    {
        [SerializeField]
        private List<InventorySlotData> m_DefaultSlots;

        public List<InventorySlotData> DefaultSlots => m_DefaultSlots;
    }
}
