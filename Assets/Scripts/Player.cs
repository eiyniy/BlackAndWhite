using BlackAndWhite.Assets.Scripts.StateMachines.Base;
using BlackAndWhite.Assets.Scripts.StateMachines.MovingStates;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        private const float ErrorFactor = 0.1f;

        private readonly StateMachine _movingStateMachine;

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _jumpingForce;

        private float _distToGround;
        private Collider2D _collider;


        public Rigidbody2D Rb => _rb;

        public float Width => _collider.bounds.size.x;
        public float Height => _collider.bounds.size.y;

        public float Acceleration
        {
            get => _acceleration;
            set => _acceleration = value;
        }

        public float MaxSpeed
        {
            get => _maxSpeed;
            set => _maxSpeed = value;
        }

        public float JumpingForce
        {
            get => _jumpingForce;
            set => _jumpingForce = value;
        }

        public State Standing { get; }
        public State Moving { get; }
        public State Jumping { get; }
        public State Falling { get; }
        

        public Player()
        {
            _movingStateMachine = new StateMachine();

            Standing = new StandingState(this, _movingStateMachine);
            Moving = new MovingState(this, _movingStateMachine);
            Jumping = new JumpingState(this, _movingStateMachine);
            Falling = new FallingState(this, _movingStateMachine);

            _movingStateMachine.Initialize(Standing);
        }


        void Start()
        {
            _collider = GetComponent<Collider2D>();
            _distToGround = Height / 2;
        }

        void Update()
        {
            _movingStateMachine.CurrentState.HandleInput();
            _movingStateMachine.CurrentState.LogicUpdate();
        }

        void FixedUpdate()
        {
            _movingStateMachine.CurrentState.PhysicsUpdate();
        }


        public bool IsGrounded() =>
            Physics2D.Raycast(Rb.position + new Vector2(Width / 2 - ErrorFactor, 0), -Vector2.up, _distToGround) ||
            Physics2D.Raycast(Rb.position - new Vector2(Width / 2 - ErrorFactor, 0), -Vector2.up, _distToGround);
    }
}
