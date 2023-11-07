using System;
using System.Collections.Generic;
using UnityEngine;
using VoxelPlay;

namespace Duck.Scripts.Inventory
{
    public class InventoryController : MonoBehaviour
    {
        public List<ItemDefinition> defaultItems;
        private VoxelPlayEnvironment m_VoxelPlayEnvironment;
       
      
        private void Start()
        {
            m_VoxelPlayEnvironment = VoxelPlayEnvironment.instance;
            InventoryInit();
        }

        private void InventoryInit()
        {
            InventoryAddItem(defaultItems);
        }
        public void InventoryAddItem(ItemDefinition itemDefinition)
        {
            VoxelPlayPlayer.instance.PickUpItem(itemDefinition);

        }
        public void InventoryAddItem(List<ItemDefinition> itemDefinition)
        {
            foreach (var item in itemDefinition)
            {
                VoxelPlayPlayer.instance.PickUpItem(item);
            }
           
        }

        public void InventoryDeleteItem(ItemDefinition itemDefinition)
        {
            VoxelPlayPlayer.instance.ConsumeItem(itemDefinition);
        }
        public void InventoryDeleteItem(List<ItemDefinition> itemDefinition)
        {
            foreach (var item in itemDefinition)
            {
                VoxelPlayPlayer.instance.ConsumeItem(item);
            }
        }

        public void InventoryCanSelectedItem(ItemDefinition itemDefinition)
        {
            itemDefinition.canBePicked = true;
        }

        public void InventoryCanNotSelectedItem(ItemDefinition itemDefinition)
        {
            itemDefinition.canBePicked = false;
        }
    }
}
