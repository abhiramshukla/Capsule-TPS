using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(FirearmController))]
public class Player : LivingEntity
{
    [SerializeField] private float _moveSpeed = 5;

    private Camera _mainCamera;
    private PlayerController _playerController;
    private FirearmController _firearmController;

    void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _firearmController = GetComponent<FirearmController>();
        _mainCamera = Camera.main;
    }

    void Update()
    {
        //Movement Input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * _moveSpeed;
        _playerController.Move(moveVelocity);

        //Look Input
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if(groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            _playerController.LookAt(point);
        }

        //Weapon Input
        if (Input.GetMouseButton(0))
            _firearmController.Shoot();
    }
}
