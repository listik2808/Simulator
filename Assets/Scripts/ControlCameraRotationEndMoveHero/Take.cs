using System;
using UnityEngine;

public class Take : MonoBehaviour
{
    [SerializeField] private float _distance = 1.5f;
    [SerializeField] private Transform _positionArm;
    private Rigidbody _rigidbody;
    private Camera _camera;
    private bool _isTake = false;
    private bool _isWork = false;

    public Action IsOnTake;

    private void Start()
    {
        _camera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && _isWork == false)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _distance) && _isTake == false)
            {
                if (hit.collider.TryGetComponent(out Product product) )
                {
                    _rigidbody = product.Rigidbody;
                    _rigidbody.isKinematic = true;
                    _rigidbody.MovePosition(_positionArm.position);
                    _rigidbody.gameObject.transform.parent = transform;
                    _isTake = true;
                    IsOnTake?.Invoke();
                }

            }
        }
    }

    public void SetWork(bool work)
    {
        _isWork = work;
    }

    public void ThrowHim()
    {
        _rigidbody.isKinematic = false;
        _rigidbody.gameObject.transform.parent = null;
        _rigidbody.AddForce(_camera.transform.forward * 250);
        _rigidbody.useGravity = true;
        _isTake = false;
    }
}
