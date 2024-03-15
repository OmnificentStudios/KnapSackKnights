using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InventorySystem;
using MoreMountains.TopDownEngine;


[CreateAssetMenu(fileName = "Hero", menuName = "NewItem/Hero")]
public class Hero_Base_SO : Items_SO
{
    [SerializeField] int Health;
    public MoreMountains.TopDownEngine.Weapon heroWeapon;
    public Sprite HeroSprite; 
    

  
    
   


}
