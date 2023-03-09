using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Swarm/Behavior/Alignment")]
public class AlignmentBehavior : SwarmFilteredBehabiour
{
    public override Vector3 CalculatePosition(SwarmMember _member, List<Transform> _context, Swarm _swarm)
    {
        //if no neighbors, maintain current alignment
        if (_context.Count == 0)
            return _member.transform.up;

        //add all points together and average
        Vector3 _alignmentMove = Vector3.zero;

        //List<Transform> _filteredObjects = (filter == null) ? _context : filter.Filter(_member, _context);

        foreach (Transform item in filteredContext)
        {
            _alignmentMove += item.transform.forward;
        }

        _alignmentMove.y = 0;
        _alignmentMove /= _context.Count;

        return _alignmentMove;
    }
}
