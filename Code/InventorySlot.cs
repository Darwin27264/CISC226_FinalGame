using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class InventorySlot : MonoBehaviour, IDropHandler
{
    public ItemScript itemScript;

    void Start()
    {
        itemScript = FindObjectOfType<ItemScript>();
    }

    public void OnDrop(PointerEventData eventData)
    {

        if (transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        } else
        {
            // merge items
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            // name of the item being moved
            Debug.Log(inventoryItem.item.name);

            // name of the item being moved on
            bool itemsMerged = false;
            // Assume a merge results in a new item, set newItemId based on the merge result
            int newItemId = -1; // Default to an invalid value


            Transform firstChildTransform = transform.GetChild(0);
            InventoryItem firstChildName = firstChildTransform.gameObject.GetComponent<InventoryItem>();
            Debug.Log(firstChildName.item.name);

            if ((inventoryItem.item.name == "YellowPotion" && firstChildName.item.name == "DarkRedPotion") || 
                (inventoryItem.item.name == "DarkRedPotion" && firstChildName.item.name == "YellowPotion"))
            {
                Debug.Log("Yellow and DarkRed = Light Orange");
                itemsMerged = true;
                newItemId = 7; // this is within Item Script in AddITems

            }
            else if ((inventoryItem.item.name == "GreyPotion" && firstChildName.item.name == "LightPurplePotion") ||
                       (inventoryItem.item.name == "LightPurplePotion" && firstChildName.item.name == "GreyPotion"))
            {
                Debug.Log("Grey and Light Purple = Purple");
                itemsMerged = true;
                newItemId = 4; 
            }

            // If items are merged, destroy or disable both items
            if (itemsMerged)
            {
                Destroy(inventoryItem.gameObject); // Destroy the item being moved
                Destroy(firstChildName.gameObject); // Destroy the item in the slot

                // Add the new item to the inventory
                itemScript.PickupItem(newItemId);
            }

        }

    }

}
