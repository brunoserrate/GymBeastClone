using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerrateDevs {
    public class PlayerInputHandler : MonoBehaviour {

        [Header("Components")]
        [SerializeField] private Rigidbody rb;

        [Header("Movement")]
        [SerializeField] private float speed = 2f;

        // Internals
        private Vector3 clickedPosition;

        private void OnEnable() {
            InputReader.OnClick += SetClickedPosition;
            InputReader.OnDrag += Move;
            InputReader.OnRelease += Stop;
        }

        private void OnDisable() {
            InputReader.OnDrag -= Move;
            InputReader.OnRelease -= Stop;
        }

        private void SetClickedPosition(Vector3 position) {
            clickedPosition = position;
        }

        private void Move(Vector3 position) {
            Vector3 direction = (position - clickedPosition).normalized;
            rb.velocity = new Vector3(direction.x * speed, 0, direction.y * speed);
        }

        private void Stop(Vector3 position) {
            rb.velocity = Vector3.zero;
        }
    }
}