using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private LayerMask _collisionMask;
    private float _speed = 10;
    private float _damage = 1;

    public void SetSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }

    void Update()
    {
        float moveDistance = _speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);
    }

    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, moveDistance, _collisionMask, QueryTriggerInteraction.Collide))
            OnHitObject(hit);
    }

    private void OnHitObject(RaycastHit hit)
    {
        IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();
        if(damageableObject != null)
        {
            damageableObject.TakeDamage(_damage, hit);
        }
        GameObject.Destroy(gameObject);
    }
}
