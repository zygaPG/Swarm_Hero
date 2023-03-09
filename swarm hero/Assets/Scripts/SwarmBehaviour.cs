using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SwarmBehaviour : ScriptableObject
{
    public abstract Vector3 CalculatePosition(SwarmMember _memeber, List<Transform> _neighbours, Swarm _swarm);
}
