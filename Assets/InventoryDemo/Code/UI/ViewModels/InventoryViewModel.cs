using System.Collections.Generic;
using Unity.Properties;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace PolytechAngers.UI
{
    [CreateAssetMenu(menuName = "Polytech Angers/UI/View Models/Inventory ViewModel")]
    public class InventoryViewModel : ScriptableObject
    {
        [InitializeOnLoadMethod]
        public static void RegisterConverters()
        {
            ConverterGroup group = new("Bool To DisplayStyle");
            group.AddConverter((ref bool v) => new StyleEnum<DisplayStyle>(v ? DisplayStyle.Flex : DisplayStyle.None));
            ConverterGroups.RegisterConverterGroup(group);
        }

        public void BindInventory(Inventory.Inventory inventory)
        {
            m_Slots.Clear();
            m_Slots.Capacity = inventory.Slots.Count;
            foreach (Inventory.InventorySlot slot in inventory.Slots)
            {
                m_Slots.Add(new(slot));
            }
        }

        [SerializeField, DontCreateProperty]
        private bool m_ShowInventory;
        [SerializeField, DontCreateProperty]
        private string m_OwnerName;

        private List<InventorySlotViewModel> m_Slots = new();

        [CreateProperty]
        public string OwnerName
        {
            get => m_OwnerName;
            set => m_OwnerName = value;
        }

        [CreateProperty]
        public bool ShowInventory
        {
            get => m_ShowInventory;
            set => m_ShowInventory = value;
        }

        [CreateProperty]
        public List<InventorySlotViewModel> Slots => m_Slots;
    }
}
