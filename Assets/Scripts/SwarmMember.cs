using UnityEngine;

public class SwarmMember : MonoBehaviour
{
    public int idPrefab = 0;

    public Swarm mySwarm;
    public float moveSpeed = 5f;

    public float timeToEat = 4;
    public bool isEating = false;
    Food currentFood;

    [SerializeField] Item itemOnBack;

    [SerializeField] Transform placeForItem;
    /// <summary>
    /// saved time when start action
    /// </summary>
    float actionStartTime;

    float currentHp = 4;


    public Collider obiectCollider
    {
        get;
        private set;
    }

    public void TryGetItemOnBack(Item _item)
    {
        if (itemOnBack == null)
            TakeItemOnBack(_item);
    }

    void TakeItemOnBack(Item _item)
    {
        itemOnBack = _item;
        _item.TakeItem(gameObject);
        _item.transform.position = placeForItem.position;
        _item.transform.localEulerAngles = Vector3.zero;
    }

    public void MoveEement(Vector3 _vector)
    {
        transform.rotation = Quaternion.LookRotation(_vector);
        transform.position += _vector;
    }


    public void StartEating(Food _food)
    {
        currentFood = _food;
        _food.StartEating(this);


        actionStartTime = Time.time;
        isEating = true;
    }

    public void FinishEating()
    {
        currentFood = null;
        isEating = false;
    }

    public void TakeHit(float _damage, Weapone _weapone = null)
    {
        currentHp -= _damage;
        if (currentHp <= 0)
            Dead();
    }

    void Dead()
    {
        if (itemOnBack != null)
        {
            itemOnBack.TrowItem();
            itemOnBack = null;
        }

        mySwarm.MemberDied(this);
    }
}
