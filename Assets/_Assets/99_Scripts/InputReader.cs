using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerrateDevs {
    public class InputReader : MonoBehaviour {
        public static Action<Vector3> OnClick;
        public static Action<Vector3> OnDrag;
        public static Action<Vector3> OnRelease;

        private void Update() {
            #if UNITY_EDITOR
            HandleMouse();
            #endif

            #if UNITY_ANDROID || UNITY_IOS
            HandleTouch();
            #endif
        }

        private void HandleMouse() {
            if (Input.GetMouseButtonDown(0)) {
                OnClick?.Invoke(Input.mousePosition);
            }

            if (Input.GetMouseButton(0)) {
                OnDrag?.Invoke(Input.mousePosition);
            }

            if (Input.GetMouseButtonUp(0)) {
                OnRelease?.Invoke(Input.mousePosition);
            }
        }

        private void HandleTouch() {
            if (Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began) {
                    OnClick?.Invoke(touch.position);
                }

                if (touch.phase == TouchPhase.Ended) {
                    OnRelease?.Invoke(touch.position);
                }

                return;
            }

            OnRelease?.Invoke(Vector3.zero);
        }

    }
}