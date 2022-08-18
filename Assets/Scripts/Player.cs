using System;
using BlackAndWhite.Assets.Scripts.StateMachines.AttackingStates;
using BlackAndWhite.Assets.Scripts.StateMachines.Base;
using BlackAndWhite.Assets.Scripts.StateMachines.MovingStates;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        private const float ErrorFactor = 0.05f;

        private readonly StateMachine _movingStateMachine;
        private readonly StateMachine _attackingStateMachine;

        #region SerializeFields

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _jumpingForce;
        [SerializeField] private int _attackCooldawn;
        [SerializeField] private int _attackCountsToReload;
        [SerializeField] private int _reloadingTime;

        #endregion SerializeFields

        private float _distToGround;
        private Collider2D _collider;


        public Rigidbody2D Rb => _rb;

        public float Width => _collider.bounds.size.x;
        public float Height => _collider.bounds.size.y;

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

        public TimeSpan AttackCooldawn
        {
            get => TimeSpan.FromMilliseconds(_attackCooldawn);
            set => _attackCooldawn = (int)value.TotalMilliseconds;
        }

        public int AttackCountsToReload
        {
            get => _attackCountsToReload;
            set => _attackCountsToReload = value;
        }
        
        public TimeSpan ReloadingTime
        {
            get => TimeSpan.FromMilliseconds(_reloadingTime);
            set => _reloadingTime = (int)value.TotalMilliseconds;
        }

        #endregion SerializeProperies

        #region States

        public State Standing { get; }
        public State Moving { get; }
        public State Jumping { get; }
        public State Falling { get; }
        
        public State Attacking { get; }
        public State Charging { get; }
        public State Cooldawn { get; }
        public State Reloading { get; }

        #endregion States


        public Player()
        {
            _movingStateMachine = new StateMachine();
            _attackingStateMachine = new StateMachine { IsLoggingEnabled = true };

            Standing = new StandingState(this, _movingStateMachine);
            Moving = new MovingState(this, _movingStateMachine);
            Jumping = new JumpingState(this, _movingStateMachine);
            Falling = new FallingState(this, _movingStateMachine);
            
            Attacking = new AttackingState(this, _attackingStateMachine);
            Charging = new ChargingState(this, _attackingStateMachine);
            Cooldawn = new CooldawnState(this, _attackingStateMachine);
            Reloading = new ReloadingState(this, _attackingStateMachine);

            _movingStateMachine.Initialize(Standing);
            _attackingStateMachine.Initialize(Cooldawn);
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

            _attackingStateMachine.CurrentState.HandleInput();
            _attackingStateMachine.CurrentState.LogicUpdate();
        }

        void FixedUpdate()
        {
            _movingStateMachine.CurrentState.PhysicsUpdate();

            _attackingStateMachine.CurrentState.PhysicsUpdate();
        }


        public bool IsGrounded() =>
            Physics2D.Raycast(Rb.position + new Vector2(Width / 2 - ErrorFactor, 0), -Vector2.up, _distToGround) ||
            Physics2D.Raycast(Rb.position - new Vector2(Width / 2 - ErrorFactor, 0), -Vector2.up, _distToGround);
    }
}
