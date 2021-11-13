using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour
{
    [SerializeField] private float _speed;
    private PlayerShot _playerShot;
    private Vector3 _currentPos;
    private void Awake()
    {
        _playerShot = FindObjectOfType<PlayerShot>();
    }
    private void Start()
    {
        _currentPos = transform.position;
        _playerShot.Shoot += OnDisableAim;
    }
   

    private void LateUpdate()
    {
        if (GameManager.instance.GameState != GameState.Play) return;
        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            transform.eulerAngles += _speed * new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f);
        }
        transform.position = Vector3.Lerp(transform.position, _currentPos, Time.deltaTime * _speed);
        
    }

    public void OnEnableAim()
    {
        if (!_playerShot.isFire) return;
        _currentPos = new Vector3(0.52f, 12f, -20f);
    }

    private void OnDisableAim()
    {
        _currentPos = new Vector3(0.52f, 12f, -27.8f);
    }

}
