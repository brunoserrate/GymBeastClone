using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerrateDevs {
    public class PlayerPunch : MonoBehaviour {
        [Header("Components")]
        [SerializeField] private Animator _animator;

        [Space(10)]

        [Header("Punch Settings")]
        [SerializeField] private float _punchAfterSeconds = 0.5f;
        [SerializeField] private float _punchForce = 500f;
        [SerializeField] private float _punchRadius = 15f;

        private WaitForSeconds _waitToApplyForce;
        private static readonly int Punch = Animator.StringToHash("Punch");

        private void Awake() {
            _waitToApplyForce = new WaitForSeconds(_punchAfterSeconds);
        }

        private void OnTriggerEnter(Collider other) {
            PunchingCharacter punchingCharacter = other.gameObject.GetComponentInParent<PunchingCharacter>();

            if (punchingCharacter == null) return;
            if (punchingCharacter.IsPunched()) return;

            _animator.SetTrigger(Punch);

            StartCoroutine(ApplyForce(punchingCharacter));
        }

        private IEnumerator ApplyForce(PunchingCharacter punchingCharacter) {
            yield return _waitToApplyForce;
            punchingCharacter.OnPunched(_punchForce, _punchRadius, -transform.forward);
        }
    }
}