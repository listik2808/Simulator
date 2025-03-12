using UnityEngine;

public class Product : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    public Rigidbody Rigidbody => _rigidbody;
}
