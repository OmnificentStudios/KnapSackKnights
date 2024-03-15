using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InventorySystem;
using MoreMountains.TopDownEngine;
using Unity.VisualScripting;


public class HeroDisplay : MonoBehaviour
{
    public Hero_Base_SO attachedHero;
    public SpriteRenderer spriteRenderer;
    SpawnController spawnController;
   
    public bool spriteChanged, spawnedHero  = false;
   

    
    
    // Start is called before the first frame update
    void Start()
    {
       spawnController = GetComponentInParent<SpawnController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spriteChanged == false && spawnedHero == true)
        {
            spriteRenderer.sprite = attachedHero.HeroSprite;

            spriteChanged = true;
        }
    }
}
