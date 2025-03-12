using UnityEngine;

namespace Assets.Scripts
{
    public class Observer : MonoBehaviour
    {
        [SerializeField] private Hud _hud;
        [SerializeField] private Take _take;
        [SerializeField] private CameraController _cameraController;

        private void OnEnable()
        {
            _take.IsOnTake += _hud.OpenButtonThrow;
            _hud.OnThrow += _take.ThrowHim;
            _cameraController.Work += _take.SetWork;
        }

        private void OnDisable()
        {
            _take.IsOnTake -= _hud.OpenButtonThrow;
            _hud.OnThrow -= _take.ThrowHim;
            _cameraController.Work -= _take.SetWork;
        }


    }
}
