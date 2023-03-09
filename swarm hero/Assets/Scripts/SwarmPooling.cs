using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SwarmPooling : MonoBehaviour
{
    public static SwarmPooling instance;

    [System.Serializable]
    public struct SwarmToSpawn
    {
        public SwarmMember prevab;

        public int minAmount;
        public int maxAmount;
    }

    [SerializeField] List<SwarmToSpawn> pools = new List<SwarmToSpawn>();




    Dictionary<int, ObjectPool<SwarmMember>> pool = new Dictionary<int, ObjectPool<SwarmMember>>();

    private void Awake()
    {
        if (SwarmPooling.instance != null)
        {
            Debug.LogError("SwarmPoling instance conflict", gameObject);
            Destroy(this);
        }

        SwarmPooling.instance = this;

        GeneratePools();
    }


    void GeneratePools()
    {
        for (int i = 0; i < pools.Count; i++)
        {
            SwarmToSpawn _toSpawn = pools[i];

            if (!pool.ContainsKey(pools[i].prevab.idPrefab))
            {
                pool.Add(pools[i].prevab.idPrefab,
                                        new ObjectPool<SwarmMember>(() =>
                                           {
                                               return Instantiate(_toSpawn.prevab);
                                           }, _element =>
                                           {
                                               _element.gameObject.SetActive(true);
                                           }, _element =>
                                           {
                                               _element.mySwarm = null;
                                               _element.gameObject.SetActive(false);
                                           }, _element =>
                                           {
                                               Destroy(_element.gameObject);
                                           }, false, _toSpawn.minAmount, _toSpawn.maxAmount)
                );
            }
        }
    }



    public SwarmMember GetNewObject(int _id)
    {
        return pool[_id].Get();
    }

    public void DeleteObject(SwarmMember _ele)
    {
        pool[_ele.idPrefab].Release(_ele);
    }

}
