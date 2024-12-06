using UnityEngine;

namespace Bullets
{
    public class Warhead : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        public void Init(Vector2 velocity)
        {
            _rb.linearVelocity = velocity;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(gameObject);
        }
    }
}