using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Swarm/Behavior/Steal Item Behaviour")]
public class StealItemBehaviour : SwarmFilteredBehabiour
{
    public override Vector3 CalculatePosition(SwarmMember _member, List<Transform> _neighbours, Swarm _swarm)
    {
        foreach (Transform _ne in filteredContext)
        {
            if ((_ne.position - _member.transform.position).magnitude < 1)
            {
                if (_ne.TryGetComponent<Item>(out Item _item))
                {
                    if (_item.owner == null)
                    {
                        _member.TryGetItemOnBack(_item);
                    }
                }
            }
        }


        return Vector3.zero;
    }
}
