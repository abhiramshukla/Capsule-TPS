using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : LivingEntity
{
    private NavMeshAgent _pathfinder;
    private Transform _target;

    void Start()
    {
        _pathfinder = GetComponent<NavMeshAgent>();
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(UpdatePath());
    }

    void Update()
    {
        
    }

    IEnumerator UpdatePath()
    {
        float refreshRate = 0.2f;

        while (_target != null)
        {
            Vector3 targetPoition = new Vector3(_target.position.x, 0, _target.position.z);
            if (!_dead) _pathfinder.SetDestination(targetPoition);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
