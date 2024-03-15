using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InventorySystem;
using MoreMountains.TopDownEngine;
using Unity.VisualScripting;
using Microsoft.Win32;
using Unity.Mathematics;

public class HeroManager : MonoBehaviour
{
    public Hero_Base_SO[] possibleHeros = new Hero_Base_SO[2];
    public InventoryController inventoryController;
    public GameObject objecttoSpawn;
  
    public HeroDisplay heroDisplay;
    public Transform spawnTransform;
    public int itemindex;
    
    

    void Start()
    {
        inventoryController = FindAnyObjectByType<InventoryController>();
    }
    void Update()
    {
       
    }
    //the two methods used, remove item and chang weapon, were not created by me.
    public void SpawnHero(InventoryItem item)
    {
        string itemInventory;
        int itemPos;
        

        itemInventory = item.GetInventory();
        itemPos = item.GetPosition();
        heroDisplay.attachedHero = item.hero_Base_SO;
        objecttoSpawn = item.GetRelatedGameObject();
        

        heroDisplay.gameObject.SetActive(true);
        heroDisplay.GetComponent<CharacterHandleWeapon>().ChangeWeapon(heroDisplay.attachedHero.heroWeapon,heroDisplay.attachedHero.heroWeapon.WeaponID,false);
        inventoryController.RemoveItem(itemInventory,item,1);
        
        heroDisplay.spawnedHero = true;
        
    }
    
}
