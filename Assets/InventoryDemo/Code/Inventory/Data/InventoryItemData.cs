using UnityEngine;
using UnityEngine.Localization;

namespace PolytechAngers.Inventory
{
    [CreateAssetMenu(menuName = "Polytech Angers/Inventory/Inventory Item Data")]
    public class InventoryItemData : ScriptableObject
    {
        [SerializeField]
        private LocalizedString m_ItemName;
        [SerializeField]
        private LocalizedSprite m_ItemSprite;

        public LocalizedString ItemName => m_ItemName;
        public LocalizedSprite ItemSprite => m_ItemSprite;
    }
}
