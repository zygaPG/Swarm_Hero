using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectsFilter : ScriptableObject
{
    public abstract List<Transform> Filter(SwarmMember agent, List<Transform> original);
}
