using System;
using System.Collections;
using UnityEngine;

namespace UdeM.Characters {
    public class Character2DBehaviour : CharacterBehaviour
    {
        protected Rigidbody2D _rb;
        protected float _radiusOverlap;

        protected override void Awake()
        {
            base.Awake();
            _radiusOverlap = 0.2f;
        }

        protected override void Start()
        {
            base.Start();
            _rb = GetComponent<Rigidbody2D>();
            if (_rb == null) {
                Debug.LogError("The Rigidbody2D component, isn't attached to the object");
            }
            _rb.freezeRotation = true;
        }

        protected override void Update()
        {
            base.Update();
            CheckGrounded();
        }

        protected virtual void CheckGrounded() {
            _isGrounded = Physics2D.OverlapCircle(transform.position, _radiusOverlap, _layerTerrain) != null;
        }
    }
}