using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Weapone
{
    public override void UseItem(float _time)
    {
        Atack();
    }

    void Atack()
    {
       
        StartCoroutine(FlyAtack(owner.transform.forward));
       
    }


    IEnumerator FlyAtack(Vector3 _direction)
    {
        TrowItem();
        RaycastHit hit;

        Vector3 _startPos = transform.position;

        Vector3 _velocity = _direction.normalized * SO.moveSpeed;

        while (true)
        {
            yield return new WaitForEndOfFrame();

            if (Physics.Raycast(transform.position, _velocity * Time.deltaTime, out hit, hitableObjects))
            {
                if (hit.transform.TryGetComponent<TakeHit>(out TakeHit _takeHit))
                {
                    _takeHit.GetHit(SO.damage, this);
                    transform.position = hit.point;
                    break;
                }
            }
            else
            {

                if ((_startPos - transform.position).magnitude >= SO.range)
                {
                    transform.position = _startPos + (_direction.normalized * SO.range);
                    break;
                }

                transform.position += _velocity * Time.deltaTime;
            }
        }
    }
}
