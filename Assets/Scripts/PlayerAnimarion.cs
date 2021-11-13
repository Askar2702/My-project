using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimarion : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private const string RELOAD = "Reload";
    private PlayerShot _playerShot;

    private void Awake()
    {
        _playerShot = FindObjectOfType<PlayerShot>();
    }
    private void Start()
    {
        _playerShot.Shoot += CheckBullet;
    }
    private void CheckBullet()
    {
        if (_playerShot._countFire <= 0)
        {
            _animator.SetTrigger(RELOAD);
            StartCoroutine(EndedReload(_animator.runtimeAnimatorController.animationClips[1].length));
        }
    }

    private IEnumerator EndedReload(float timer)
    {
        yield return new WaitForSeconds(timer + 1f);
        _playerShot.SettingCount(); 
    }
}
