using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/item so")]
public class ItemSO : ScriptableObject
{
    public Vector3 positionInHands;
    public Vector3 rotationInHands;

    public Vector3 positionInBack;
    public Vector3 rotationInBack;


    public float timeToUse = 0.8f;

    public float range = 10;

    public float moveSpeed = 25;
    public float damage = 10;
}
