using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{

    private Camera _mainCamera;

    [Header("Canvas for Readings")]
    public GameObject craftingCanvas; // Canvas for Papers
    public GameObject bookCanvas; // Canvas for Books
    public GameObject diaryCanvas;  // Canvas for Diary
    public GameObject posterCanvas; // Canvas for Poster
    
    public GameObject tableCanvas; // Canvas for Table Items
    public GameObject yellowPotion; 
    public GameObject dark_red_Potion;
    public GameObject test_tubes;

    public GameObject shelveCanvas; // Canvas for Shelve Items
    public GameObject greenPotion;
    public GameObject redPotion;
    public GameObject bluePotion;


    public GameObject UICanvas;
    public GameObject MouseToolbar;


    public ItemScript itemScript;
    void Start()
    {
        itemScript = FindObjectOfType<ItemScript>();
    }


    public void Awake()
    {
        _mainCamera = Camera.main;
        // Ensure all canvases start as not visible
        craftingCanvas.SetActive(false);
        bookCanvas.SetActive(false);
        diaryCanvas.SetActive(false);
        posterCanvas.SetActive(false);
        tableCanvas.SetActive(false);
        shelveCanvas.SetActive(false);

        UICanvas.SetActive(true);
        MouseToolbar.SetActive(false);

    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var ray = _mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit2D rayHit = Physics2D.GetRayIntersection(ray);

        // Debug.Log(rayHit.collider.gameObject.name);

        // If any canvas is active and the click is not on an interactable object, deactivate all canvases
        if ((craftingCanvas.activeSelf || bookCanvas.activeSelf || diaryCanvas.activeSelf || posterCanvas.activeSelf || tableCanvas.activeSelf || shelveCanvas.activeSelf) &&
            (rayHit.collider == null || (rayHit.collider.gameObject.name != "Papers" && rayHit.collider.gameObject.name != "Books" &&
                                         rayHit.collider.gameObject.name != "Diary" && rayHit.collider.gameObject.name != "Poster" && 
                                         rayHit.collider.gameObject.name != "Table Craft" &&
                                         rayHit.collider.gameObject.name != "Shelf" &&
                                         rayHit.collider.gameObject.name != "dark_red_potion" &&
                                         rayHit.collider.gameObject.name != "yellow_potion" &&
                                         rayHit.collider.gameObject.name != "blue_potion" &&
                                         rayHit.collider.gameObject.name != "red_potion" &&
                                         rayHit.collider.gameObject.name != "green_potion" &&
                                         rayHit.collider.gameObject.name != "mouse" &&
                                         rayHit.collider.gameObject.name != "MouseToolbar" &&
                                         rayHit.collider.gameObject.name != "UICanvas" &&
                                         rayHit.collider.gameObject.name != "Toolbar" &&
                                         rayHit.collider.gameObject.name != "ToolbarM" &&
                                         rayHit.collider.gameObject.name != "InventorySlot" &&
                                         rayHit.collider.gameObject.name != "InventorySlot (1)" &&
                                         rayHit.collider.gameObject.name != "InventorySlot (2)" &&
                                         rayHit.collider.gameObject.name != "InventorySlot (3)" &&
                                         rayHit.collider.gameObject.name != "InventorySlot (4)" &&
                                         rayHit.collider.gameObject.name != "test_tubes")))
        {
            craftingCanvas.SetActive(false);
            bookCanvas.SetActive(false);
            diaryCanvas.SetActive(false);
            posterCanvas.SetActive(false);
            tableCanvas.SetActive(false);
            shelveCanvas.SetActive(false);
            MouseToolbar.SetActive(false);

            return;
        }

        // Toggle the active state of the associated canvas based on the object clicked
        if (rayHit.collider != null)
        {
            switch (rayHit.collider.gameObject.name)
            {
                case "Papers":
                    craftingCanvas.SetActive(!craftingCanvas.activeSelf);
                    bookCanvas.SetActive(false);
                    diaryCanvas.SetActive(false);
                    posterCanvas.SetActive(false);
                    tableCanvas.SetActive(false);
                    shelveCanvas.SetActive(false);
                    MouseToolbar.SetActive(false);


                    break;
                case "Book":
                    bookCanvas.SetActive(!bookCanvas.activeSelf);
                    craftingCanvas.SetActive(false);
                    diaryCanvas.SetActive(false);
                    posterCanvas.SetActive(false);
                    tableCanvas.SetActive(false);
                    shelveCanvas.SetActive(false);
                    MouseToolbar.SetActive(false);


                    break;
                case "Diary":
                    diaryCanvas.SetActive(!diaryCanvas.activeSelf);
                    craftingCanvas.SetActive(false);
                    bookCanvas.SetActive(false);
                    posterCanvas.SetActive(false);
                    tableCanvas.SetActive(false);
                    shelveCanvas.SetActive(false);
                    MouseToolbar.SetActive(false);


                    break;
                case "Poster":
                    posterCanvas.SetActive(!posterCanvas.activeSelf);
                    craftingCanvas.SetActive(false);
                    bookCanvas.SetActive(false);
                    diaryCanvas.SetActive(false);
                    tableCanvas.SetActive(false);
                    shelveCanvas.SetActive(false);
                    MouseToolbar.SetActive(false);


                    break;
                case "Table Craft":
                    tableCanvas.SetActive(!tableCanvas.activeSelf);
                    craftingCanvas.SetActive(false);
                    bookCanvas.SetActive(false);
                    diaryCanvas.SetActive(false);
                    posterCanvas.SetActive(false);
                    shelveCanvas.SetActive(false);
                    MouseToolbar.SetActive(false);


                    break;
                case "Shelf":
                    shelveCanvas.SetActive(!shelveCanvas.activeSelf);
                    craftingCanvas.SetActive(false);
                    bookCanvas.SetActive(false);
                    diaryCanvas.SetActive(false);
                    posterCanvas.SetActive(false);
                    tableCanvas.SetActive(false);
                    MouseToolbar.SetActive(false);


                    break;
                case "dark_red_potion":
                    Debug.Log("dark red");

                    // Add the new item to the inventory
                    itemScript.PickupItem(1);
                    Destroy(dark_red_Potion);

                    break;
                case "yellow_potion":
                    Debug.Log("yellow");

                    // Add the new item to the inventory
                    itemScript.PickupItem(6);
                    Destroy(yellowPotion);

                    break;

                case "test_tubes":
                    Debug.Log("test_tube");

                    // Add the new item to the inventory
                    itemScript.PickupItem(3);
                    itemScript.PickupItem(8);

                    Destroy(test_tubes);

                    break;

                case "red_potion":
                    Debug.Log("red");

                    // Add the new item to the inventory
                    itemScript.PickupItem(5);
                    Destroy(redPotion);

                    break;

                case "green_potion":
                    Debug.Log("green");

                    // Add the new item to the inventory
                    itemScript.PickupItem(2);
                    Destroy(greenPotion);

                    break;

                case "blue_potion":
                    Debug.Log("blue");

                    // Add the new item to the inventory
                    itemScript.PickupItem(0);
                    Destroy(bluePotion);

                    break;
                case "mouse":
                    Debug.Log("mouse ui");

                    MouseToolbar.SetActive(!MouseToolbar.activeSelf);
                    shelveCanvas.SetActive(false);
                    craftingCanvas.SetActive(false);
                    bookCanvas.SetActive(false);
                    diaryCanvas.SetActive(false);
                    posterCanvas.SetActive(false);
                    tableCanvas.SetActive(false);

                    break;
            }
        }
    }

}
