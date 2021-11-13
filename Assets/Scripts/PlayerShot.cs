using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using System;
using TMPro;

public class PlayerShot : MonoBehaviour
{
    [field: SerializeField] public int _countFire { get; private set; }
    [SerializeField] private TextMeshProUGUI _countBullet;
    public event Action Shoot;
    public event Action<Transform, string> Fire;
    public event Action Move;
    private Camera _camera;
    public bool isFire { get; private set; }
    private void Awake()
    {
        _camera = Camera.main; 
        SettingCount();
        isFire = true;
    }

    private void Update()
    {
        if (GameManager.instance.GameState != GameState.Play) return;
        if (_countFire <= 0) isFire = false;
        else isFire = true;
        if (!isFire) return;
        RaycastHit hit;
#if UNITY_EDITOR
        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(_camera.transform.position , _camera.transform.forward , out hit))
            {
                if (hit.transform.GetComponent<Rigidbody>() && isFire)
                {
                    Fire?.Invoke(hit.transform, hit.collider.name);
                }
            }
            _countFire--;
            _countBullet.text = _countFire.ToString();
            Shoot?.Invoke();
        }
#endif
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            if (touch.phase == TouchPhase.Ended)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.GetComponent<Rigidbody>() && isFire)
                    {
                        Fire?.Invoke(hit.transform, hit.collider.name);
                    }
                }
                _countFire--;
                _countBullet.text = _countFire.ToString();
                Shoot?.Invoke();
            }

        }
#endif
    }

    
    public void SettingCount()
    {
        _countFire = 10;
        _countBullet.text = _countFire.ToString();
    }
    
    
}

