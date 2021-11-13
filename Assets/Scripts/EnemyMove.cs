using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float _roofPosY;
    [SerializeField] private float _speed;
    private Animator _animator;
    private const string CLIMB = "IsClimbing";
    public void Init(float s)
    {
        _animator = GetComponent<Animator>();
        _speed += s;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.instance.GameState != GameState.Play) return;
        if (transform.position.y < _roofPosY)
            transform.Translate(Vector3.up * Time.deltaTime * _speed);
        else if (transform.position.y >= _roofPosY)
        {
            _animator.SetBool(CLIMB , true);
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            GameManager.instance.FinishGame();
        }
    }
}
