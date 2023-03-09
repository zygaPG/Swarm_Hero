using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swarm : MonoBehaviour
{
    [SerializeField] SwarmMember prevabMember;
    [SerializeField] SwarmBehaviour randomWalkingBehaviour;
    [SerializeField] SwarmBehaviour followTargetBehaviour;

    [SerializeField] List<SwarmMember> members;
    [SerializeField] LayerMask maskForCollisions;


    [SerializeField] float startMembersAmount = 10;
    [SerializeField] float spawnRadious = 10;

    public float avoidanceDistance = 1;
    [SerializeField] float collisionRadious = 4;

    public Vector3 stayInRadiousCenter = new Vector3();
    public float stayInRadiousRange = 10;


    public Transform target;

    /// <summary>
    /// culdown to calculate new swarm center
    /// </summary>
    [SerializeField] float circleCenterInvokeCuldown = 0.2f;
    Vector3 swarmCenter;
    Coroutine circleCenter;


    delegate void curState();

    curState currentState;



    private void Start()
    {
        RespawnRandomSwarm();
        circleCenter = StartCoroutine(UpdateSwarmCenterInvoke());

        currentState = RandomWalking;
        stayInRadiousCenter = transform.position;
    }



    void Update()
    {
        currentState();
    }



    void ExecuteBeaviour(SwarmBehaviour _behaviour)
    {
        if (_behaviour != null && members != null)
        {
            foreach (SwarmMember _se in members)
            {

                Vector3 _move = _behaviour.CalculatePosition(_se, GetNerbyObjects(_se, collisionRadious), this);


                if (_move.magnitude > 0)
                {
                    _move = _move.normalized * _se.moveSpeed * Time.deltaTime;
                    _se.MoveEement(_move);
                } 
            }
        }
    }




    #region change State

    void FollowTarget()
    {
        if (Vector3.Distance(target.position, swarmCenter) > 5)
        {
            ExecuteBeaviour(followTargetBehaviour);
            stayInRadiousCenter = transform.position;
        }
    }

    void RandomWalking()
    {
        ExecuteBeaviour(randomWalkingBehaviour);
    }



    void StayInPlace()
    {

    }


    void Atack()
    {

    }

    void RunAway()
    {

    }


    void Patrol()
    {

    }

    void StartEat()
    {

    }



    #endregion











    void RespawnRandomSwarm()
    {
        members.Clear();
        for (int i = 0; i < startMembersAmount; i++)
        {
            members.Add(SwarmPooling.instance.GetNewObject(prevabMember.idPrefab));
            members[^1].mySwarm = this;
            members[^1].transform.position = transform.position + new Vector3(Random.Range(-1.1f, 1.1f), 0, Random.Range(-1.1f, 1.1f)).normalized * Random.Range(0, spawnRadious);
        }
    }


    List<Transform> GetNerbyObjects(SwarmMember _target, float _radious)
    {
        List<Transform> _neighbours = new List<Transform>();

        Collider[] _nerbycolliders;
        _nerbycolliders = Physics.OverlapSphere(_target.transform.position, _radious, maskForCollisions);
        foreach (Collider _co in _nerbycolliders)
        {
            if (_co != _target.obiectCollider)
            {
                _neighbours.Add(_co.transform);
            }

        }
        return _neighbours;
    }


    private IEnumerator UpdateSwarmCenterInvoke()
    {
        while (true)
        {
            foreach (SwarmMember _member in members)
            {
                swarmCenter += _member.transform.position;
            }

            swarmCenter /= members.Count;

            Debug.DrawRay(swarmCenter, Vector3.up * 24, Color.blue, circleCenterInvokeCuldown);
            transform.position = swarmCenter;

            yield return new WaitForSeconds(circleCenterInvokeCuldown);
        }
    }



    public void MemberDied(SwarmMember _member)
    {
        if(_member != null)
            if (members.Contains(_member))
            {
                members.Remove(_member);
                SwarmPooling.instance.DeleteObject(_member);
            }

    }




#if UNITY_EDITOR
    private void OnDrawGizmos()
    {



    }
#endif
}
