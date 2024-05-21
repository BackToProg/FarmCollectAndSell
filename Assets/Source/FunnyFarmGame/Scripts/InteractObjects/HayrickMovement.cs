using Source.Modules.Infrastructure.Actions;
using UnityEngine;

namespace Source.FunnyFarmGame.Scripts.InteractObjects
{
    [RequireComponent(typeof(Rigidbody))]
    public class HayrickMovement : MonoBehaviour
    {
        [SerializeField] private float _moveToTargetSpeed;

        private bool _isMoveToTarget;
        private Transform _targetTransform;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (_isMoveToTarget)
            {
                MoveToSellPoint();
            }
        }

        public void PickUp(Transform haybalePositionTransform, Transform collectedTransform)
        {
            transform.position = collectedTransform.position;
            transform.rotation = collectedTransform.rotation;
            transform.parent = haybalePositionTransform;
            _rigidbody.isKinematic = true;
        }

        public void MoveToTarget(Transform targetTransform)
        {
            _targetTransform = targetTransform;
            _isMoveToTarget = true;
        }

        private void MoveToSellPoint()
        {
            _rigidbody.useGravity = false;

            transform.position = Vector3.MoveTowards(transform.position, _targetTransform.position,
                _moveToTargetSpeed * Time.deltaTime);

            transform.parent = _targetTransform;

            if (Vector3.Distance(transform.position, _targetTransform.position) < Mathf.Epsilon)
            {
                gameObject.SetActive(false);
                _isMoveToTarget = false;
            }
        }
    }
}