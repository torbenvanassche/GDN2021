using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MechanicController : MonoBehaviour
{
    private enum PlayerState
    {
        Human,
        Ash
    }

    [SerializeField] private PlayerState state = PlayerState.Human;

    private Mover _mover;

    [SerializeField] private float ashHeight = 0.1f;
    private float _humanHeight = 0;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _humanHeight = _mover.colliderHeight;
    }

    public void ToggleAsh()
    {
        switch (state)
        {
            case PlayerState.Human:
                state = PlayerState.Ash;
                _mover.colliderHeight = ashHeight;
                break;
            case PlayerState.Ash:
                state = PlayerState.Human;
                _mover.colliderHeight = _humanHeight;
                break;
        }
        
        _mover.RecalculateColliderDimensions();
    }
}
