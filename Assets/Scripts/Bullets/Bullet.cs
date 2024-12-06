using System;
using Unity.Mathematics;
using UnityEngine;

namespace Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _impulse;
        [Space]
        [SerializeField] private Warhead _warheadPrefab;
        [SerializeField, Range(1, 5)] private int _countOfWarheads;
        
        private bool _warheadsIsInited;
        
        public void Init(float angle)
        {
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            _rb.AddForce(direction * _impulse, ForceMode2D.Impulse);   
        }

        private void Update()
        {
            if(_warheadsIsInited)
                return;
            if (_rb.linearVelocity.y < 0)
                InitWarheads();
        }

        private void InitWarheads()
        {
            _warheadsIsInited = true;
            float distanceMultiplier = 1f;
            for (int i = 0; i < _countOfWarheads; i++)
            {
                var warhead = Instantiate(_warheadPrefab, transform.position, quaternion.identity);
                warhead.Init(_rb.linearVelocity * distanceMultiplier);
                distanceMultiplier -= .2f;
            }
            Destroy(gameObject);
        }
    }
}