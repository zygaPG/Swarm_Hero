using System.Collections;
using UnityEngine;

public class Food : MonoBehaviour
{
    public SwarmMember owner;

    public float timeToEat;



    public void StartEating(SwarmMember _member)
    {
        owner = _member;
        timeToEat = _member.timeToEat;
        StartCoroutine(Eat());
    }


    //operation on another thread
    IEnumerator Eat()
    {
        yield return new WaitForSeconds(timeToEat);

        owner.FinishEating();
        Destroy(gameObject);
    }
}
