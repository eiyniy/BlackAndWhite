using System;
using BlackAndWhite.Assets.Scripts.Attack;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        private const float ErrorFactor = 0.05f;

        private Collider2D _collider;
        private float _distToGround;

        #region SerializeFields

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private GameObject _weaponsHolder;

        #endregion SerializeFields


        public Rigidbody2D Rb => _rb;

        public float Width => _collider.bounds.size.x;
        public float Height => _collider.bounds.size.y;

        public Weapon Weapon { get; set; }


        public Player()
        {
        }


        void Start()
        {
            _collider = GetComponent<Collider2D>();
            _distToGround = Height / 2;

            Weapon = _weaponsHolder.GetComponent<Transform>().GetChild(0).GetComponent<Weapon>();
        }


        public void UpdateVelocity(float acceleration, float maxSpeed, float horizontalInput)
        {
            if (horizontalInput == 0)
                return;

            var direction = (int)(horizontalInput / Math.Abs(horizontalInput));
            Debug.Log(direction);

            if (Math.Abs(Rb.velocity.x) >= maxSpeed && (Rb.velocity.x * direction) > 0)
                return;

            Rb.velocity += acceleration * new Vector2(direction, 0f) * Time.deltaTime;
        }

        public bool IsGrounded() =>
            Physics2D.Raycast(Rb.position + new Vector2(Width / 2 - ErrorFactor, 0), -Vector2.up, _distToGround) ||
            Physics2D.Raycast(Rb.position - new Vector2(Width / 2 - ErrorFactor, 0), -Vector2.up, _distToGround);
    }
}
