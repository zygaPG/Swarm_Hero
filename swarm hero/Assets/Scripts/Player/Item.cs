using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemSO SO;

    public GameObject owner;

    [SerializeField] Collider myCollider;

    [SerializeField] Rigidbody rb;


    public virtual void TakeItem(GameObject _owner)
    {
        rb.isKinematic = true;
        owner = _owner;
        myCollider.enabled = false;
        transform.parent = owner.transform;
        
    }

    public virtual void TrowItem()
    {
        if(owner.TryGetComponent<PlayerInventory>(out PlayerInventory _inventory))
        {
            _inventory.DisconectItem(this);
        }

        owner = null;
        myCollider.enabled = true;
        transform.parent = null;
        rb.isKinematic = false;
        rb.velocity = Vector3.zero;
    }


    public virtual void UseItem(float _time =0)
    {
        
    }

}
