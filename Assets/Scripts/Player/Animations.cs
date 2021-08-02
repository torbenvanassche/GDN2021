using System;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private SidescrollerController _controller;
    private Animator _animator;
    
    private static readonly int JumpHash = Animator.StringToHash("Jump");
    private static readonly int Move = Animator.StringToHash("Move");

    private void Awake()
    {
        _controller = GetComponent<SidescrollerController>();
        _animator = GetComponent<Animator>();

        _controller.OnJump += Jump;
    }

    private void Update()
    {
        if (_controller)
        {
            _animator.SetFloat(Move, Math.Abs(_controller.savedVelocity.x));
        }
    }

    private void Jump(Vector3 v)
    {
        _animator.SetTrigger(JumpHash);
    }
}
