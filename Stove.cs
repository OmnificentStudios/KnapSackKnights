using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using MoreMountains.TopDownEngine;


public class Stove : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private RectTransform inventoryRectTransform; // Changed from GameObject to RectTransform
        [SerializeField] private float distance;
        [SerializeField] private Vector3 offset;
        [SerializeField] GameObject text;
        [SerializeField] GameObject combineButton;
        private Camera mainCamera;
        private Canvas canvas; // The canvas that the inventory is a child of
        [SerializeField] Hero_Base_SO[] combineList = new Hero_Base_SO[4];
        public InventoryController inventoryController;
        public Items_SO combinedItem;
        public Items_SO  item1, item2;
        public TextController textController;
        bool stepChanged = false;

        private void Start()
        {
            textController = FindObjectOfType<TextController>();
            //Not mine____ FROM HERE
            text.SetActive(true);
            mainCamera = Camera.main;
           
          
            // Assuming the parent of the inventory is the canvas
            canvas = inventoryRectTransform.GetComponentInParent<Canvas>();
              inventoryController = FindObjectOfType<InventoryController>();
        }

        private void Update()
        {
            
            if(player == null){ player = FindAnyObjectByType<PlayerCharacter>().gameObject;}
            Vector2 screenPoint = mainCamera.WorldToScreenPoint(transform.position);

            // Convert screen point to canvas space
            Vector2 canvasPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), screenPoint, canvas.worldCamera, out canvasPoint);

            inventoryRectTransform.anchoredPosition = canvasPoint; // Use anchoredPosition for UI elements
            inventoryRectTransform.position = inventoryRectTransform.position + offset;
            //________ TO HERE
            if ((player.transform.position - transform.position).magnitude < distance)
            {
                InventoryController.instance.AddToggleKey("Chest", 'e');
                text.SetActive(true);
                if(stepChanged == false)
                {
                    textController.currentStep = 3;
                    textController.changingStep = true;
                    stepChanged = true;  
                }

            }
            else
            {
                inventoryRectTransform.gameObject.SetActive(false);
                InventoryController.instance.RemoveToggleKey("Chest", 'e');
                text.SetActive(false);
                if(stepChanged == true)
                { 
                    textController.currentStep = 4;
                    textController.changingStep = true;
                }

            }
            if(InventoryController.instance.InventoryFull("Chest", "Food") == true)
            {
                combineButton.SetActive(true);
            }
            else{combineButton.SetActive(false);}
        }
         public void Combine()
         {
            item1 = inventoryController.GetItem("Chest",0).items_SO;
            item2 = inventoryController.GetItem("Chest",1).items_SO;
            if(item1.itemType == "Fruit" && item2.itemType == "Fruit")
            {
                combinedItem = combineList[0];
            }
            else if(item1.itemType == "Veg" && item2.itemType == "Veg")
            {
                combinedItem = combineList[1];
            }
            else if(item1.itemType == "Fruit" && item2.itemType == "Veg" || item1.itemType == "Veg" && item2.itemType == "Fruit" )
            {
                combinedItem = combineList[2];
            }
             else if(item1.itemType == "Meat" && item2.itemType == "Veg" || item1.itemType == "Veg" && item2.itemType == "Meat" )
            {
                combinedItem = combineList[3];
            }
            inventoryController.AddItem("Menu", combinedItem.itemName,1);
            inventoryController.RemoveItem("Chest", item1.itemName, 1);
            inventoryController.RemoveItem("Chest", item2.itemName, 1);
         }
         
    }


