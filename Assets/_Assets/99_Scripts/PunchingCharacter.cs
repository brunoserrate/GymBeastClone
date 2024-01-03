using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerrateDevs {
    public class PunchingCharacter : MonoBehaviour {

        [Header("Components")]
        [SerializeField] private Rigidbody _mainRb;
        [SerializeField] private Animator _animator;

        // Internal
        private bool _isPunched;

        private void Start() {

            Rigidbody[] rbs = GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody rb in rbs) {
                rb.isKinematic = true;
            }
        }

        public void OnPunched(float punchForce = 1000, float radius = 10, Vector3 explosionDirection = default) {
            _animator.enabled = false;
            _isPunched = true;

            Rigidbody[] rbs = GetComponentsInChildren<Rigidbody>();

            _mainRb.isKinematic = false;

            foreach (Rigidbody rb in rbs) {
                rb.isKinematic = false;
                rb.AddExplosionForce(punchForce, transform.position + explosionDirection, radius);
            }
        }

        public bool IsPunched() {
            return _isPunched;
        }

    }
}