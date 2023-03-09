using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Swarm/Behavior/Cohesion")]
public class CohesionBehavior : SwarmBehaviour
{
    public override Vector3 CalculatePosition(SwarmMember _member, List<Transform> _context, Swarm _swarm)
    {
        //if no neighbors, return no adjustment
        if (_context.Count == 0)
            return Vector3.zero;

        //add all points together and average
        Vector3 _cohesionMove = Vector3.zero;
        //List<Transform> filteredContext = (filter == null) ? _context : filter.Filter(_target, _context);
        foreach (Transform item in _context)
        {
            _cohesionMove += item.position;
        }

        _cohesionMove /= _context.Count;

        //create offset from agent position
        _cohesionMove -= _member.transform.position;
        _cohesionMove.y = 0;
        return _cohesionMove;
    }
}
