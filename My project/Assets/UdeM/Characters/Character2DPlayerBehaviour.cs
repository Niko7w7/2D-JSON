using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdeM.Characters {
    public class Character2DPlayerBehaviour : Character2DBehaviour
    {
       protected float _axisH;

        protected override void Update()
        {
            base.Update();
            _axisH = Input.GetAxis("Horizontal");
            Move();

            if (Input.GetButtonDown("Jump") && _isGrounded) {
                Jump();
            }
        }

        protected override void Move()
        {
            base.Move();
            _rb.velocity = new Vector2(_axisH * _moveSpeed, _rb.velocity.y);
        }

        protected override void Jump()
        {
            base.Jump();
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
    }
}
