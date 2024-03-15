using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using InventorySystem;

public class TextController : MonoBehaviour
{
  public GameObject s1,s2,s3,s4;
  public int currentStep;
  public bool changingStep = true;
  private InventoryController inventoryController;
  

   void Start()
   {
        inventoryController = FindObjectOfType<InventoryController>();
        s1.gameObject.SetActive(false);
        s2.gameObject.SetActive(false);
        s3.gameObject.SetActive(false);
        s4.gameObject.SetActive(false);
        currentStep = 1; changingStep = true;
        
   }
    void Update()
    {
        if(changingStep == true)
        {
            if(currentStep == 1) {s1.gameObject.SetActive(true); changingStep = false;}
            if(currentStep == 2) {s2.gameObject.SetActive(true); s1.gameObject.SetActive(false); changingStep = false;}
            if(currentStep == 3) {s3.gameObject.SetActive(true); s2.gameObject.SetActive(false); changingStep = false;}
            if(currentStep == 4) {s4.gameObject.SetActive(true); s3.gameObject.SetActive(false); changingStep = false;}

        }
        if(currentStep == 1 && inventoryController.GetItem("Main",1).GetItemImage() != null) 
        {
            changingStep = true;
            currentStep = 2;
            
        }

    }
 
}
