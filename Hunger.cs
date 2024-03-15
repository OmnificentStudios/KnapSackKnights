using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class Hunger : MonoBehaviour
{
    public GameObject CustomerPF;
    public Health health;
    public Character myState;
    public bool died, SpawnedCustomer = false;

    
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
       if(this.GetComponent<Character>().ConditionState.CurrentState == CharacterStates.CharacterConditions.Dead)
       {
            died = true;
       }
       if(died == true && SpawnedCustomer == false)
       {
            SpawnCustomer();
            SpawnedCustomer = true;
       }
    }
    public void SpawnCustomer()
    {
        Instantiate<GameObject>(CustomerPF,this.gameObject.transform.position,Quaternion.identity);
    }
}
