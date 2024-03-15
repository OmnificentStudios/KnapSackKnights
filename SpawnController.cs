using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InventorySystem;
using MoreMountains.TopDownEngine;
using Unity.VisualScripting;
using Microsoft.Win32;
using Unity.Mathematics;

public class SpawnController : MonoBehaviour
{
    HeroManager heroManager;
    public HeroDisplay heroDisplay;
     public Sprite standTopIdleS, standTopSpawnedS;
     public Transform standTopT;
      public SpriteRenderer StandTop;

    // Start is called before the first frame update
    void Start()
    {
        heroManager = FindObjectOfType<HeroManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player") == true)
        {
            heroManager.heroDisplay = heroDisplay;

        }
    }
    public void ChangeStand()
    {
        // Changes top depending on the Hero
        if(heroDisplay.spawnedHero == true)
        {
            StandTop.sprite = standTopSpawnedS;
            standTopT.localPosition = new Vector3(0,(float)0.663,0);
        }
        else{standTopT.localPosition = new Vector3(0,(float)0.37,0); StandTop.sprite = standTopIdleS;}
    }
}
