using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InventorySystem;
using MoreMountains.TopDownEngine;
using Unity.VisualScripting;
using System.Linq;
using MoreMountains.Tools;

using MoreMountains.Feedbacks;

public class LootingManager : MonoBehaviour
{
    public CollectableUnit[] collectable;
    private InventoryController inventoryController;
    public MMHealthBar[] mMHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        collectable = new CollectableUnit[FindObjectsOfType<CollectableUnit>().Count()];
        inventoryController = FindObjectOfType<InventoryController>(); Debug.Log("InventoryController Attached");
        mMHealthBar = new MMHealthBar[collectable.Length];

    }

    // Update is called once per frame
    void Update()
    {
        
            if(collectable[0] == null)
            {
                collectable = FindObjectsOfType<CollectableUnit>();

            }
                for (int i = 0; i < mMHealthBar.Length; i++)
                {
                    if(mMHealthBar[i] == null)
                    {
                      mMHealthBar[i] = collectable[i].GetComponent<MMHealthBar>();
                    
                    }
                }

        
    }
   
}
