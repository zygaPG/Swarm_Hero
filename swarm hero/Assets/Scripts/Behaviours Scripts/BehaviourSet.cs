using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Swarm/Behavior/Set")]
public class BehaviourSet : SwarmBehaviour
{
    public SwarmBehaviour[] behaviors;
    public float[] weights;

    public override Vector3 CalculatePosition(SwarmMember _member, List<Transform> _context, Swarm _swarm)
    {
        //handle data mismatch
        //if (weights.Length != behaviors.Length)
        //{
        //    Debug.LogError("Data mismatch in " + name, this);
        //    return Vector3.zero;
        //}

        //set up move
        Vector3 _move = Vector3.zero;

        Dictionary<ObjectsFilter, List<Transform>> _filtered = new Dictionary<ObjectsFilter, List<Transform>>();



        //iterate through behaviors
        for (int i = 0; i < behaviors.Length; i++)
        {
            //if eating find behaviour is fist, skip movement 
            if (_member.isEating)
                return Vector3.zero;



            //dont find filter list twice
            if (behaviors[i] is SwarmFilteredBehabiour _beh)
            {
                if (!_filtered.ContainsKey(_beh.filter))
                {
                    _beh.filteredContext = _beh.filter.Filter(_member, _context);

                    _filtered.Add(_beh.filter, _beh.filteredContext);
                }
                else
                {
                    _beh.filteredContext = _filtered[_beh.filter];
                } 
            }



            Vector3 _partialMove = behaviors[i].CalculatePosition(_member, _context, _swarm) * weights[i];

            if (_partialMove != Vector3.zero)
            {
                if (_partialMove.magnitude > weights[i])
                {
                    _partialMove.Normalize();
                    _partialMove *= weights[i];
                }

                _move += _partialMove;

            }
        }

        return _move;
    }
}
