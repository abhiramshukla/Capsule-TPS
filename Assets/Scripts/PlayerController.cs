using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Vector3 _playerVelocity;
    private Rigidbody _playerRigidBody;

    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 velocity)
    {
        _playerVelocity = velocity;
    }

    public void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedLookPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedLookPoint);
    }

    void FixedUpdate()
    {
        _playerRigidBody.MovePosition(_playerRigidBody.position + _playerVelocity * Time.fixedDeltaTime);
    }
}
