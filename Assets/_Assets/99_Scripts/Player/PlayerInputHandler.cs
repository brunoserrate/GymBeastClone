using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerrateDevs {
    public class PlayerInputHandler : MonoBehaviour {

        [Header("Components")]
        [SerializeField] private PlayerMovement playerMovement;

        // Internals
        private Vector3 clickedPosition;

        private void OnEnable() {
            InputReader.OnClick += SetClickedPosition;
            InputReader.OnDrag += MoveRotate;
            InputReader.OnRelease += Stop;
        }

        private void OnDisable() {
            InputReader.OnDrag -= MoveRotate;
            InputReader.OnRelease -= Stop;
        }

        private void SetClickedPosition(Vector3 position) {
            clickedPosition = position;
        }

        private void MoveRotate(Vector3 position) {
            Vector3 direction = (position - clickedPosition).normalized;
            playerMovement.Move(direction);
            playerMovement.Rotate(direction);
        }

        private void Stop(Vector3 position) {
            playerMovement.Stop();
        }
    }
}