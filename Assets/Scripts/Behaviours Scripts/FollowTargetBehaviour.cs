using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Swarm/Behavior/FollowTarget")]
public class FollowTargetBehaviour : SwarmBehaviour
{
    public override Vector3 CalculatePosition(SwarmMember _member, List<Transform> _neighbours, Swarm _swarm)
    {
        if (_neighbours != null && _neighbours.Count > 0 && _swarm.target != null)
        {
            Vector3 _move = (_swarm.target.position -_swarm.transform.position).normalized * _member.moveSpeed;
            _move.y = 0;
            return _move;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
