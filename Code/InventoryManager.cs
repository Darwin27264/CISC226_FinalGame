using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    public void AddItem(Item item)
    {
        // Find any empty slot
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();

            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return;
            }
        }
    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item);
    }

    // Method to check if items in slots 5 to 9 are all filled
    public bool CheckItemNamesInSlots()
    {
        List<string> potions = new List<string>();

        for (int i = 5; i <= 9; i++) // Indexes 5 to 9 assuming your array has at least 10 elements.
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();

            // If any slot in the range is empty, return false
            if (itemInSlot == null)
            {
                Debug.Log("Slot " + i + " is empty.");
                return false; // Early return if a slot is found empty
            }
            else
            {
                // Output the name of the GameObject to which InventoryItem is attached
                Debug.Log("Slot " + i + " contains item: " + itemInSlot.item.name);
                potions.Add(itemInSlot.item.name);

            }
        }

        if (potions.Contains("PurplePotion") && potions.Contains("RedPotion") && potions.Contains("GreenPotion")
            && potions.Contains("LightOrangePotion") && potions.Contains("BluePotion"))
        {
            // If the method hasn't returned false by this point, all slots are filled
            return true;
        }

        return false;
    }

}
