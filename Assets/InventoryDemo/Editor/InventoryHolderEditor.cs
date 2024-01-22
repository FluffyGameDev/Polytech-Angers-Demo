using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace PolytechAngers.Inventory.Editor
{
    [CustomEditor(typeof(InventoryHolder))]
    public class InventoryHolderEditor : UnityEditor.Editor
    {
        [SerializeField]
        private VisualTreeAsset m_EditorTemplate;

        private static readonly string k_EmptySlot = "Empty Slot";
        private static readonly string k_ItemsListName = "lst_items";

        public override VisualElement CreateInspectorGUI()
        {
            VisualElement root = m_EditorTemplate.Instantiate();
            root.Bind(serializedObject);

            InventoryHolder targetHolder = (InventoryHolder)serializedObject.targetObject;
            if (targetHolder.Inventory != null)
            {
                ListView itemsList = root.Q<ListView>(k_ItemsListName);
                itemsList.makeItem = CreateItemElement;
                itemsList.bindItem = BindItemElement;
                itemsList.itemsSource = targetHolder.Inventory.Slots;

                foreach (InventorySlot slot in targetHolder.Inventory.Slots)
                {
                    slot.OnSlotChanged += _ => itemsList.Rebuild();
                }
            }

            return root;
        }

        private VisualElement CreateItemElement()
        {
            return new Label();
        }

        private void BindItemElement(VisualElement element, int index)
        {
            Label label = (Label)element;
            InventoryHolder targetHolder = (InventoryHolder)serializedObject.targetObject;

            InventorySlot slot = targetHolder.Inventory.Slots[index];
            InventoryItemData itemData = slot.ItemType;
            string itemName = itemData != null ? itemData.ItemName.GetLocalizedString() : k_EmptySlot;
            string itemQuantityPostfix = itemData != null ? $" x{slot.Quantity}" : string.Empty;

            label.text = $"- {itemName}{itemQuantityPostfix}";
        }
    }
}
