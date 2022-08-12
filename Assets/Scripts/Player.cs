using UnityEngine;

namespace BlackAndWhite.Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        private readonly StateMachine _stateMachine;

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _jumpingForce;


        public Rigidbody2D Rb => _rb;

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


        public Player()
        {
            _stateMachine = new StateMachine();
            Standing = new StandingState(this, _stateMachine);
            Moving = new MovingState(this, _stateMachine);
            Jumping = new JumpingState(this, _stateMachine);

            _stateMachine.Initialize(Standing);
        }


        void Update()
        {
            _stateMachine.CurrentState.HandleInput();
            _stateMachine.CurrentState.LogicUpdate();
        }

        void FixedUpdate()
        {
            _stateMachine.CurrentState.PhysicsUpdate();
        }
    }
}
