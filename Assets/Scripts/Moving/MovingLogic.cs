using BlackAndWhite.Assets.Scripts.BaseStateMachine;
using BlackAndWhite.Assets.Scripts.Moving.MovingStates;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts.Moving
{
    public class MovingLogic : MonoBehaviour
    {
        private readonly StateMachine _movingStateMachine;

        private Player _player;

        #region SerializeFields

        [SerializeField] private float _acceleration;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _jumpingForce;

        #endregion SerializeFields


        #region SerializeProperies

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

        #endregion SerializeProperies

        #region States

        public State Standing { get; private set; }
        public State Moving { get; private set; }
        public State Jumping { get; private set; }
        public State Falling { get; private set; }

        #endregion States


        public MovingLogic()
        {
            _movingStateMachine = new StateMachine();
        }


        void Start()
        {
            _player = GetComponent<Player>();

            Standing = new StandingState(_player, this, _movingStateMachine);
            Moving = new MovingState(_player, this, _movingStateMachine);
            Jumping = new JumpingState(_player, this, _movingStateMachine);
            Falling = new FallingState(_player, this, _movingStateMachine);

            _movingStateMachine.Initialize(Standing);
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
    }
}