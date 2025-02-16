using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SwarmFilteredBehabiour : SwarmBehaviour
{
    public List<Transform> filteredContext;
    public ObjectsFilter filter;
}
