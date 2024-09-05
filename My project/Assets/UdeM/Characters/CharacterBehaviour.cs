using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdeM.Base;

namespace UdeM.Characters {
    public class CharacterBehaviour : CustomMonoBehaviour
    {
        protected float _moveSpeed;
        protected string _name;
        protected float _jumpForce;
        [SerializeField] protected bool _isGrounded;
        protected LayerMask _layerTerrain;

        protected override void Awake()
        {
            base.Awake();
            _moveSpeed = 5f;
            _jumpForce = 10f;
            _isGrounded = false;
        }

        protected override void Start()
        {
            base.Start();
            _layerTerrain = LayerMask.GetMask("Terrain");
        }

        protected virtual void Jump(){}
        protected virtual void Move(){}
    }
}
