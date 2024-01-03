using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace SerrateDevs {
    public class PlayerMovement : MonoBehaviour {

        [Header("Components")]
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private Animator _animator;

        [Header("Movement")]
        [SerializeField] private float _speed = 2f;

        [Header("Rotation")]
        [SerializeField] private float _rotationSpeed = 500f;

        private static readonly int Speed = Animator.StringToHash("Speed");

        private void Awake() {
            if (_animator == null) _animator = GetComponentInChildren<Animator>();
        }

        public void Move(Vector3 direction) {
            _rb.velocity = new Vector3(direction.x * _speed, 0, direction.y * _speed);
            _animator.SetFloat(Speed, Mathf.Abs(direction.x) + Mathf.Abs(direction.y));
        }

        public void Rotate(Vector3 direction) {
            Vector3 lookDirection = new Vector3(direction.x, 0, direction.y);

            if (lookDirection == Vector3.zero) return;

            Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
        }

        public void Stop() {
            _rb.velocity = Vector3.zero;
            _animator.SetFloat(Speed, 0);
        }
    }
}