using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Swarm/Behavior/Swarm In Radius")]
public class StayInRadiusBehavior : SwarmBehaviour
{

    public override Vector3 CalculatePosition(SwarmMember _member, List<Transform> _context, Swarm _swarm)
    {
        Vector3 _centerOffset = _member.mySwarm.stayInRadiousCenter - _member.transform.position;
        float t = _centerOffset.magnitude / _member.mySwarm.stayInRadiousRange;
        if (t < 0.9f)
        {
            return Vector3.zero;
        }

        _centerOffset.y = 0;
        return _centerOffset * t * t;
    }
}
