using System;

namespace PolytechAngers.Inventory
{
    public class InventorySlot
    {
        public InventoryItemData ItemType => m_ItemType;
        public int Quantity => m_Quantity;
        public event Action<InventorySlot> OnSlotChanged;

        public bool CanAddItem(InventoryItemData itemType) => m_ItemType == null || m_ItemType == itemType;

        public bool AddItem(InventoryItemData itemType, int quantity)
        {
            if (m_ItemType == null || m_ItemType == itemType)
            {
                m_ItemType = itemType;
                m_Quantity += quantity;

                OnSlotChanged?.Invoke(this);
                return true;
            }

            return false;
        }

        private InventoryItemData m_ItemType;
        private int m_Quantity;
    }
}