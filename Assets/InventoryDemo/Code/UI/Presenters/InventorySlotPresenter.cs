using PolytechAngers.Inventory;
using UnityEngine.UIElements;

namespace PolytechAngers.UI
{
    public class InventorySlotPresenter
    {
        private static readonly string k_ItemIconImageName = "img_item-icon";
        private static readonly string k_ItemNameLabelName = "lbl_item-name";

        private VisualElement m_Root;
        private VisualElement m_ItemIconImage;
        private Label m_ItemNameLabel;
        private InventorySlot m_Slot;

        public void Bind(VisualElement root, InventorySlot slot)
        {
            m_Root = root;
            m_Slot = slot;

            m_ItemIconImage = m_Root.Q(k_ItemIconImageName);
            m_ItemNameLabel = m_Root.Q<Label>(k_ItemNameLabelName);

            RefreshSlot(m_Slot);

            m_Slot.OnSlotChanged += RefreshSlot;
        }

        public void Unbind()
        {
            m_Slot.OnSlotChanged -= RefreshSlot;

            m_Root = null;
            m_Slot = null;
        }

        private void RefreshSlot(InventorySlot slot)
        {
            m_ItemIconImage.style.backgroundImage = m_Slot.ItemType != null ? new StyleBackground(slot.ItemType.ItemSprite.LoadAsset()) : null;
            m_ItemNameLabel.text = m_Slot.ItemType != null ? $"{m_Slot.ItemType.ItemName.GetLocalizedString()} x{m_Slot.Quantity}" : "";
        }
    }
}
