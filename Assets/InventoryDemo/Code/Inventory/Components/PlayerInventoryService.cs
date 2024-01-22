using System;
using UnityEngine;

namespace PolytechAngers.Inventory
{
    public class PlayerInventoryService : MonoBehaviour
    {
        [SerializeField]
        private InventoryHolder m_PlayerInventoryHolder;

        public static Inventory PlayerInventory => s_Instance.m_PlayerInventoryHolder.Inventory;

        private static PlayerInventoryService s_Instance;
        public static PlayerInventoryService Instance => s_Instance;

        private void Awake()
        {
            if (s_Instance == null)
            {
                s_Instance = this;
            }
            else
            {
                Debug.LogError("Multiple instances of PlayerInventoryService.", s_Instance);
            }
        }

        private void OnDestroy()
        {
            if (s_Instance == this)
            {
                s_Instance = null;
            }
        }
    }
}
