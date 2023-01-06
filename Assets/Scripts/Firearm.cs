using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firearm : MonoBehaviour
{
    [SerializeField] private Transform _muzzle;
    [SerializeField] private Projectile _projectile;
    [SerializeField] private float _msBetweenShots = 100;
    [SerializeField] private float _muzzleVelocity = 35;
    private float _nextShotTime;

    public void Shoot()
    {
        if(Time.time > _nextShotTime)
        {
            _nextShotTime = Time.time + (_msBetweenShots/1000);
            Projectile newProjectile = Instantiate(_projectile, _muzzle.position, _muzzle.rotation) as Projectile;
            newProjectile.SetSpeed(_muzzleVelocity);
        }
    }
}
