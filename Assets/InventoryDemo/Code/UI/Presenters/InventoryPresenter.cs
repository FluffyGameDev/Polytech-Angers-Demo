using PolytechAngers.Inventory;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace PolytechAngers.UI
{
    public class InventoryPresenter : MonoBehaviour
    {
        [SerializeField]
        private UIDocument m_Document;
        [SerializeField]
        private string m_RootName;
        [SerializeField]
        private ShowInventoryEvent m_ShowInventoryEvent;

        private static readonly string k_OwnerLabelName = "lbl_owner-name";
        private static readonly string k_ItemListViewName = "lst_items";

        private VisualElement m_InventoryRoot;
        private Label m_OwnerLabel;
        private ListView m_ItemListView;
        private InventoryHolder m_BoundInventory;

        private Dictionary<int, InventorySlotPresenter> m_SlotPresenters = new();

        private void Awake()
        {
            m_InventoryRoot = m_Document.rootVisualElement.Q(m_RootName);
            m_OwnerLabel = m_InventoryRoot.Q<Label>(k_OwnerLabelName);
            m_ItemListView = m_InventoryRoot.Q<ListView>(k_ItemListViewName);

            m_ItemListView.bindItem = OnBindInventoryItem;
            m_ItemListView.unbindItem = OnUnbindInventoryItem;

            m_ShowInventoryEvent.OnEventTriggered += OnShowInventoryEvent;
        }

        private void OnDestroy()
        {
            m_ShowInventoryEvent.OnEventTriggered -= OnShowInventoryEvent;
        }

        private void OnShowInventoryEvent(InventoryHolder inventoryHolder)
        {
            bool makeDisplayed = m_InventoryRoot.style.display == DisplayStyle.None;
            m_InventoryRoot.style.display = makeDisplayed ? DisplayStyle.Flex : DisplayStyle.None;

            if (makeDisplayed)
            {
                m_BoundInventory = inventoryHolder;
                m_ItemListView.itemsSource = m_BoundInventory.Inventory.Slots;
                m_OwnerLabel.text = m_BoundInventory.HolderName;
            }
        }

        private void OnBindInventoryItem(VisualElement root, int index)
        {
            InventorySlotPresenter slotPresenter = new();
            slotPresenter.Bind(root, m_BoundInventory.Inventory.Slots[index]);

            m_SlotPresenters.Add(index, slotPresenter);
        }

        private void OnUnbindInventoryItem(VisualElement root, int index)
        {
            if (m_SlotPresenters.Remove(index, out var slotPresenter))
            {
                slotPresenter.Unbind();
            }
        }
    }
}
