using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Swarm/Filter/Tag Filter")]
public class TagFilter : ObjectsFilter
{
    [SerializeField] string tag ="";

    public override List<Transform> Filter(SwarmMember _member, List<Transform> _group)
    {


        List<Transform> _filtered = new List<Transform>();

        foreach (Transform _item in _group)
        {

            if (_item.CompareTag(tag))
            {
                _filtered.Add(_item);
            }
        }

        return _filtered;
    }
}
