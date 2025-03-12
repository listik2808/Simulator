using System;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    [SerializeField] private Button _throw;

    public Action OnThrow;

    private void OnEnable()
    {
        _throw.onClick.AddListener(CloseBatton);
    }

    private void OnDisable()
    {
        _throw.onClick.RemoveListener(CloseBatton);
    }

    public void OpenButtonThrow()
    {
        _throw.gameObject.SetActive(true);
    }

    private void CloseBatton()
    {
        _throw.gameObject.SetActive(false);
        OnThrow?.Invoke();
    }
}
