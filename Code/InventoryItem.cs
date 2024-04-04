using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // public Item item;

    [Header("UI")]
    public Image image;

    [HideInInspector] public Item item;
    [HideInInspector] public Transform parentAfterDrag;

    public InventoryManager inventoryManager; // Assign this via the inspector

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>(); // Find the InventoryManager instance
    }


    public void InitializeItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
    }

    // Drag and drop
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        // transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
        CheckItemsInInventory();

    }
    private void CheckItemsInInventory()
    {

        bool slotsFilled = inventoryManager.CheckItemNamesInSlots();

        if (slotsFilled)
        {
            Debug.Log("potions have been made");


            // Switch to ending scene    
            ChangeSceneWithDelay(2);

        }
    }
    public void ChangeSceneWithDelay(int sceneName)
    {
        StartCoroutine(DelaySceneLoad(sceneName));
    }

    IEnumerator DelaySceneLoad(int sceneName)
    {
        yield return new WaitForSeconds(1f); // Wait for 2 seconds
        SceneManager.LoadScene(sceneName); // Load the scene
    }
}

