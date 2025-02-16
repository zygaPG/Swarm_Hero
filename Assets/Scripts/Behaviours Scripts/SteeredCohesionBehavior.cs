using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Swarm/Behavior/Steered Cohesion")]
public class SteeredCohesionBehavior : SwarmFilteredBehabiour
{

    Vector3 currentVelocity;
    public float agentSmoothTime = 0.5f;

    public override Vector3 CalculatePosition(SwarmMember _member, List<Transform> _context, Swarm _swarm)
    {
        //if no neighbors, return no adjustment
        if (_context.Count == 0)
            return Vector2.zero;

        //add all points together and average
        Vector3 _cohesionMove = Vector3.zero;

        //List<Transform> _filteredContext = (filter == null) ? _context : filter.Filter(_member, _context);
        foreach (Transform item in filteredContext)
        {
            _cohesionMove += item.position;
        }
        _cohesionMove /= _context.Count;


        //create offset from agent position
        _cohesionMove -= _member.transform.position;

        _cohesionMove = Vector3.SmoothDamp(_member.transform.up, _cohesionMove, ref currentVelocity, agentSmoothTime);

        _cohesionMove.y = 0;
        return _cohesionMove;
    }
}
