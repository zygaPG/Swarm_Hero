using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Swarm/Behavior/Avoidance")]
public class AvoidanceBehavior : SwarmFilteredBehabiour
{
    

    public override Vector3 CalculatePosition(SwarmMember _member, List<Transform> _context, Swarm _swarm)
    {
        //if no neighbors, return no adjustment
        if (_context.Count == 0)
            return Vector3.zero;

        //add all points together and average
        Vector3 _avoidanceMove = Vector3.zero;
        int _nAvoid = 0;

        

        foreach (Transform _item in filteredContext)
        {
            if ((_item.position - _member.transform.position).sqrMagnitude < _swarm.avoidanceDistance)
            {
                _nAvoid++;
                _avoidanceMove += (_member.transform.position - _item.position);
            }
        }
        //i want move only in x/y
        _avoidanceMove.y = 0;

        if (_nAvoid > 0)
            _avoidanceMove /= _nAvoid;

        return _avoidanceMove;
    }
}
