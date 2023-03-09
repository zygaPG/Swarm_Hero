using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    [SerializeField] PlayerInventory inventory;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Atack();
        }
    }


    void Atack()
    {
        
        if (inventory.CurrentItem && (inventory.CurrentItem is Weapone _weapone))
        {
            _weapone.Fire();
        }
    }
}
