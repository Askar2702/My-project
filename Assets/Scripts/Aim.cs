using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class Aim : MonoBehaviour
{
    [SerializeField] private Transform _aim;
    [SerializeField] private Transform _aim2;
    [Range(1f, 10f)]
    [SerializeField] private float _speed;
    private Camera _camera;
    private float _fieldOfView = 60f;
    private float _scale = 0.2f;
    private float _currentScale = 0.2f;
    private PlayerShot _playerShot;

    private void Awake()
    {
        _camera = Camera.main;
        _playerShot = FindObjectOfType<PlayerShot>();
    }
    private void Start()
    {
        _playerShot.Shoot += OnDisableAim;
    }

    private void Update()
    {
        if (GameManager.instance.GameState != GameState.Play) return;
        _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, _fieldOfView, Time.deltaTime * _speed);
        _currentScale = Mathf.Lerp(_currentScale, _scale, Time.deltaTime * _speed);
        _aim.localScale = new Vector3(_currentScale, _currentScale);
        if(_currentScale <= 0.3f)
        {
            _aim.gameObject.SetActive(false);
            _aim2.gameObject.SetActive(true);
        }
        else if (_currentScale > 0.3f)
        {
            _aim.gameObject.SetActive(true);
            _aim2.gameObject.SetActive(false);
        }
    }
    public void OnEnableAim()
    {
        if (!_playerShot.isFire) return;
        _scale = 1f;
        _fieldOfView = 10;
    }

    private void OnDisableAim()
    {
        _scale = 0.2f;
        _fieldOfView = 60;
        if(_aim.gameObject.activeSelf)
            transform.DOShakePosition(0.5f, new Vector3(0f, 2f, 0f));
    }
}
