using System;
using Bullets;
using Unity.Mathematics;
using UnityEngine;

namespace Cannon
{
    public class CannonShooter : MonoBehaviour
    {
        [SerializeField] private CannonRotator _rotator;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _spawner;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(_bulletPrefab, _spawner.position, quaternion.identity).Init(_rotator._currentAngle);
            }
        }
    }
}