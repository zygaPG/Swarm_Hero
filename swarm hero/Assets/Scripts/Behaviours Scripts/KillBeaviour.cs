using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Swarm/Behavior/Kill Beaviour")]
public class KillBeaviour : SwarmFilteredBehabiour
{
    public override Vector3 CalculatePosition(SwarmMember _member, List<Transform> _neighbours, Swarm _swarm)
    {
        foreach (Transform _ne in filteredContext)
        {
            if ((_ne.position - _member.transform.position).magnitude < 2)
            {
                if (_ne.TryGetComponent<SwarmMember>(out SwarmMember _target))
                {
                    if (_target.idPrefab != _member.idPrefab)
                    {
                        _target.TakeHit(10);
                    }
                }
            }
        }


        return Vector3.zero;
    }
}
