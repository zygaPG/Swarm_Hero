using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Swarm/Filter/Same Swarm Filter")]
public class SameSwarmFilter : ObjectsFilter
{
    public override List<Transform> Filter(SwarmMember _member, List<Transform> _group)
    {
        List<Transform> _filtered = new List<Transform>();
        foreach (Transform _item in _group)
        {

            if (_item.TryGetComponent<SwarmMember>(out SwarmMember _sm))
            {
                if (_sm.mySwarm != _item)
                    _filtered.Add(_item);
            }

            //if (_member.mySwarm.IsObjectInSwarmMembers(_item))
            //    _filtered.Add(_item);
        }

        return _filtered;
    }


}
