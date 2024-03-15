using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;
using Unity.VisualScripting;

public class ItemPickup : MonoBehaviour
{
   // Start is called before the first frame update
        [SerializeField]
        string ItemName;
        
        public Food_ItemSO food;
       private LootingManager lootingManager;

        void Start()
        {
            this.GetComponent<SpriteRenderer>().sprite = food.pickupSprite;
            ItemName = food.itemName;
            lootingManager = FindObjectOfType<LootingManager>();
            
        }
        void Awake()
        {
            
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (!InventoryController.instance.InventoryFull("Main", ItemName))
                {
                    InventoryController.instance.AddItem("Main", ItemName, 1);
                    Destroy(gameObject);

                }
                else
                {
                    Debug.Log("Inventory Cannot Fit Item");
                }

            }
        }
}
