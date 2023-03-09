using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Swarm/Behavior/Check For Food")]
public class CheckForFood : SwarmFilteredBehabiour
{
    public override Vector3 CalculatePosition(SwarmMember _member, List<Transform> _neighbours, Swarm _swarm)
    {
        foreach(Transform _ne in filteredContext)
        {
            if ((_ne.position - _member.transform.position).magnitude < 1)
            {
                if (_ne.TryGetComponent<Food>(out Food _food)) 
                {
                    if (_food.owner == null)
                    {
                        _member.StartEating(_food);
                    }
                }
            }
        }
            

        return Vector3.zero;
    }
}
