using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerrateDevs {
    public class MobileJoystick : MonoBehaviour {

        [Header("Components")]
        [SerializeField] private RectTransform _joystick;
        [SerializeField] private RectTransform _joystickKnob;

        private void Start() {
            HideJoyStick();
        }

        private void OnEnable() {
            InputReader.OnClick += OnClicked;
            InputReader.OnDrag += MoveKnob;
            InputReader.OnRelease += OnReleased;
        }

        private void OnDisable() {
            InputReader.OnClick -= OnClicked;
            InputReader.OnDrag -= MoveKnob;
            InputReader.OnRelease -= OnReleased;
        }

        private void MoveKnob(Vector3 position) {
            if(!_joystick.gameObject.activeSelf) return;

            Vector3 direction = position - _joystick.position;

            if (direction.magnitude > _joystick.sizeDelta.x / 2f) {
                direction = direction.normalized * _joystick.sizeDelta.x / 2f;
            }

            _joystickKnob.anchoredPosition = direction;
        }

        public void OnClicked(Vector3 position) {
            ShowJoyStick();
            _joystick.position = position;
        }

        public void OnReleased(Vector3 position) {
            HideJoyStick();
        }

        private void HideJoyStick() {
            _joystick.gameObject.SetActive(false);
        }

        private void ShowJoyStick() {
            _joystick.gameObject.SetActive(true);
        }
    }
}