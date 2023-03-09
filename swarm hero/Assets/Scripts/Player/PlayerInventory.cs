using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] LayerMask itemMask;
    [SerializeField] string itemTag = "Item";
    int itemCapacity = 2;

    [SerializeField] List<Item> items = new List<Item>();

    [SerializeField] int currentItemInHands = 0;

    [SerializeField] float takeItemRange = 2;

    public Item CurrentItem
    {
        get
        {
            if (items.Count > currentItemInHands)
            {
                return items[currentItemInHands];
            }

            return null;
        }
    }


    public void TakeItem(Item _item)
    {
        if (_item == null)
            return;

        if (items.Count < itemCapacity)
        {
            _item.TakeItem(gameObject);
            AddItem(_item);
        }
    }

    void AddItem(Item _item)
    {
        items.Add(_item);

        _item.TakeItem(gameObject);

        VisualizeItems();
    }

    public void DisconectItem(Item _item)
    {
        if (_item)
            if (items.Contains(_item))
            {
                items.Remove(_item);
                _item.TrowItem();
            }
    }


    void VisualizeItems()
    {
        if (currentItemInHands < items.Count)
        {
            ShowItemOnHands(items[currentItemInHands]);
        }


        if (items.Count > 1)
        {
            if (currentItemInHands == 1) // secound item in hands
            {
                ShowItemOnBack(items[0]); //firs item in back
            }
            else
            {
                ShowItemOnBack(items[1]);
            }
        }
    }

    /// <summary>
    /// set positon and rotation item inside player hands
    /// </summary>
    /// <param name="_itm"></param>
    void ShowItemOnHands(Item _itm)
    {
        _itm.transform.parent = this.transform;
        _itm.transform.localPosition = _itm.SO.positionInHands;
        _itm.transform.localEulerAngles = _itm.SO.rotationInHands;
    }


    /// <summary>
    /// set positon and rotation item inside player Back
    /// </summary>
    /// <param name="_itm"></param>
    void ShowItemOnBack(Item _itm)
    {
        _itm.transform.parent = this.transform;
        _itm.transform.localPosition = _itm.SO.positionInBack;
        _itm.transform.localEulerAngles = _itm.SO.rotationInBack;
    }




    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeItem(TryTakeItem());
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            TrowItem(CurrentItem);
        }

        float scrollValue = Input.GetAxis("Mouse ScrollWheel");

        if (scrollValue != 0)
        {
            if (scrollValue > 0)
            {
                if (currentItemInHands < items.Count || currentItemInHands == 0)
                {
                    currentItemInHands++;
                }
                else
                {
                    currentItemInHands = 0;
                }
            }

            if (scrollValue < 0)
            {
                if (currentItemInHands > 0)
                {
                    currentItemInHands--;
                }
                else
                {
                    currentItemInHands = items.Count - 1;
                }
            }

            VisualizeItems();
        }
    }

    void TrowItem(Item _item)
    {
        if (_item != null)
            _item.TrowItem();
    }


    Item TryTakeItem()
    {
        Transform _closestItem = null;
        float _minDistance = float.MaxValue;

        Collider[] _nerbycolliders = Physics.OverlapSphere(transform.position, takeItemRange, itemMask);


        foreach (Collider _co in _nerbycolliders)
        {
            if (_co.transform.CompareTag(itemTag))
            {
                if (_closestItem == null || Vector3.Distance(_co.transform.position, transform.position) < _minDistance)
                {
                    _closestItem = _co.transform;
                    _minDistance = Vector3.Distance(_co.transform.position, transform.position);
                }
            }
        }

        if (_closestItem)
        {
            return _closestItem.GetComponent<Item>();
        }
        else
        {
            return null;
        }


    }
}
