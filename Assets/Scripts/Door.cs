using UnityEngine;

public class Door : MonoBehaviour
{
    public const string Open = "Open";
    public const string Close = "Close";
    [SerializeField] private float _distance = 3;

    private bool _isOpen = false;

    [SerializeField] private Animator _animator;

    private void OpenDoorAndClose()
    {
        if (_isOpen == false)
        {
            _animator.SetTrigger(Open);
            _isOpen = true;
        }
        else
        {
            _animator.SetTrigger(Close);
            _isOpen = false;
        }
        
    }

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _distance))
        {
            if (hit.collider.TryGetComponent(out Door door))
            {
                door.OpenDoorAndClose();
            }
        }
    }
}
