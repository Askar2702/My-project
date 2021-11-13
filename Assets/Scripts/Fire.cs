using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private PlayerShot _player;
    private float _headShoot = 200;
    private float _bodyShoot = 40;
    private Transform _enemy;
    private float _damage = 40;

    private void Awake()
    {
        _player.Fire += SetTarget;
    }

    private void SetTarget(Transform enemy , string str)
    {
        if (str == "Head") _damage = _headShoot;
        else _damage = _bodyShoot;

        _enemy = enemy;

        var e = _enemy.GetComponentInParent<Enemy>();
       
        if (e.Health < _damage)
            Shoot();
        e.TakeDamage(_damage);
    }
    private void Shoot()
    {
        var g = _enemy.GetComponentsInParent<Animator>();
        for (int i = 0; i < g.Length; i++)
            g[i].enabled = false;


        _enemy.GetComponent<Rigidbody>().AddForce(transform.forward * 5000, ForceMode.Force);
    }
}
