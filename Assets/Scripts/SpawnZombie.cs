using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    [SerializeField] private EnemyMove _enemy;
    private float _rate = 4f;
    private float _factor = 0.001f;
    private float _speed;
    private void Start()
    {
        InvokeRepeating("Spawn", 0, _rate);
    }
    private void Spawn()
    {
        if (GameManager.instance.GameState != GameState.Play) return;
        var pos = new Vector3(Random.Range(-5, 5), transform.position.y, transform.position.z);
        var e = Instantiate(_enemy, pos, Quaternion.identity);
        e.transform.parent = transform;
        _speed += _factor;
        e.Init(_speed);
    }
}
