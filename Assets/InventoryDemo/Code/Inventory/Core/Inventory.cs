using System.Collections.Generic;

namespace PolytechAngers.Inventory
{
    public class Inventory
    {
        public List<InventorySlot> Slots => m_Slots;

        public Inventory(int slotCount)
        {
            m_Slots.Capacity = slotCount;
            for (int i = 0; i < slotCount; ++i)
            {
                m_Slots.Add(new());
            }
        }

        public bool CanAddItem(InventoryItemData item)
        {
            return m_Slots.Exists(slot => slot.CanAddItem(item));
        }

        public void AddItem(InventoryItemData item, int quantity)
        {
            m_Slots.Exists(slot => slot.AddItem(item, quantity));
        }

        private List<InventorySlot> m_Slots;
    }
}