
using System;
using BlackAndWhite.Assets.Scripts.Attack.WeaponStates;
using BlackAndWhite.Assets.Scripts.BaseStateMachine;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts.Attack
{
    public enum AttackElement { Black, White }


    public class Weapon : MonoBehaviour
    {
        private readonly StateMachine _weaponStateMachine;

        #region SerializeFields

        [SerializeField] private Transform _firePoint;

        #endregion SerializeFields


        #region SerializeProperies

        public Transform FirePoint
        {
            get => _firePoint;
            set => _firePoint = value;
        }

        #endregion SerializeProperies

        #region States

        public State Attacking { get; }
        public State Charging { get; }
        public State Cooldawn { get; }
        public State Reloading { get; }

        #endregion States

        public AttackElement AttackElement { get; set; }

        public int Damage { get; private set; }

        public TimeSpan AttackCooldawn { get; private set; }
        
        public int AttackCountsToReload { get; private set; }

        public TimeSpan ReloadingTime { get; private set; }


        public Weapon() 
        {
            _weaponStateMachine = new StateMachine { IsLoggingEnabled = true };

            Attacking = new AttackingState(this, _weaponStateMachine);
            Charging = new ChargingState(this, _weaponStateMachine);
            Cooldawn = new CooldawnState(this, _weaponStateMachine);
            Reloading = new ReloadingState(this, _weaponStateMachine);
        }


        void Start()
        {
            _weaponStateMachine.Initialize(Cooldawn);
        }

        void Update()
        {
            _weaponStateMachine.CurrentState.HandleInput();
            _weaponStateMachine.CurrentState.LogicUpdate();
        }

        void FixedUpdate()
        {
            _weaponStateMachine.CurrentState.PhysicsUpdate();
        }

        public Weapon Construct(int damage, TimeSpan attackCooldawn, int attackCountsToReload, TimeSpan reloadingTime)
        {
            Damage = damage;
            AttackElement = AttackElement.Black;
            AttackCooldawn = attackCooldawn;
            AttackCountsToReload = attackCountsToReload;
            ReloadingTime = reloadingTime;

            return this;
        }
    }
}