using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TakeHit : MonoBehaviour
{
    
    public TakeHitEvent OnTakeHit;

    public void GetHit(float _dmg, Weapone _weapone)
    {
        OnTakeHit.Invoke(_dmg, _weapone);
    }

}

[System.Serializable]
public class TakeHitEvent : UnityEvent<float, Weapone> { }
