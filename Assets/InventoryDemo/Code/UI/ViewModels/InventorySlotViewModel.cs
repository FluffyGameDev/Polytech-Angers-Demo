using PolytechAngers.Inventory;
using System;
using System.Collections.Generic;
using Unity.Properties;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace PolytechAngers.UI
{
    public class InventorySlotViewModel : INotifyBindablePropertyChanged
    {
        public InventorySlotViewModel(InventorySlot slot)
        {
            m_Slot = slot;
            m_Slot.OnSlotChanged += OnSlotChanged;
        }

        [CreateProperty]
        public string ItemName => m_Slot.ItemType != null ? $"{m_Slot.ItemType.ItemName.GetLocalizedString()} x{m_Slot.Quantity}" : "";
        [CreateProperty]
        public Sprite ItemSprite => m_Slot.ItemType != null ? m_Slot.ItemType.ItemSprite.LoadAsset() : null;

        public event EventHandler<BindablePropertyChangedEventArgs> propertyChanged;

        private void OnSlotChanged(InventorySlot slot)
        {
            propertyChanged?.Invoke(this, new BindablePropertyChangedEventArgs(nameof(ItemName)));
            propertyChanged?.Invoke(this, new BindablePropertyChangedEventArgs(nameof(ItemSprite)));
        }

        private InventorySlot m_Slot;
    }
}
