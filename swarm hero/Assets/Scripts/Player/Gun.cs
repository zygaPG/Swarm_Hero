using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapone 
{ 
    public override void Fire()
    {
        Debug.DrawRay(transform.position, owner.transform.forward * SO.range, Color.cyan, 15);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, owner.transform.forward * SO.range, out hit, hitableObjects))
        {
            if (hit.transform.TryGetComponent<TakeHit>(out TakeHit _takeHit))
            {
                _takeHit.GetHit(SO.damage, this);
            }
        }
    }

}
