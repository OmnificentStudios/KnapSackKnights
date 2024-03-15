using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InventorySystem;
using MoreMountains.TopDownEngine;
using MoreMountains.Tools;

using MoreMountains.Feedbacks;
using System;
using Unity.Mathematics;
using Unity.VisualScripting;

public class CollectableUnit : MonoBehaviour
{
    //Loot droping functionality for resource level
    public bool unitDefeated;
    public bool lootDropped = false;
    public Food_ItemSO attachedFI;
    public GameObject dropOnDeath;
    Health health;
    public Character character;
   

  
    void Start()
    {
        dropOnDeath = this.attachedFI.pickUpGO;
        character = this.GetComponent<Character>();
        health = this.GetComponent<Health>();
        unitDefeated = false;
    }

        void Update()
    {
        if(health.CurrentHealth <= 0){unitDefeated = true;}
        if(unitDefeated == true && lootDropped == false)
        {
           DropLoot();
        }
        
    }
    public void DropLoot()
    {
            GameObject DroppedItem;
           DroppedItem =  Instantiate<GameObject>(dropOnDeath, this.transform.position, quaternion.identity);
           DroppedItem.GetComponent<ItemPickup>().food = attachedFI;
           lootDropped = true;
           Debug.Log("LootDropped");
           
    }
 
}
