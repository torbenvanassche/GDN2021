﻿using UnityEngine;

public class SidescrollerController : AdvancedWalkerController
{
    private Mechanics _mechanics;
    
    protected override void Setup()
    {
        _mechanics = GetComponent<Mechanics>();
    }

    //Calculate movement direction based on player input;
    protected override Vector3 CalculateMovementDirection()
    {
        //If no character input script is attached to this object, return;
        if (characterInput == null)
            return Vector3.zero;

        Vector3 _velocity = Vector3.zero;

        //If no camera transform has been assigned, use the character's 'right' transform axis to calculate the movement direction;
        if (cameraTransform == null)
        {
            _velocity += tr.right * characterInput.GetHorizontalMovementInput();
        }
        else
        {
            //If a camera transform has been assigned, use the assigned transform's 'right' axis for movement direction;
            //Project movement direction so movement stays parallel to the ground;
            _velocity += Vector3.ProjectOnPlane(cameraTransform.right, tr.up).normalized *
                         characterInput.GetHorizontalMovementInput();
        }

        if (_mechanics.GetState() == Mechanics.PlayerState.Ash)
        {
            //If no camera transform has been assigned, use the character's 'right' transform axis to calculate the movement direction;
            if (cameraTransform == null)
            {
                _velocity += tr.up * characterInput.GetVerticalMovementInput();
            }
            else
            {
                //If a camera transform has been assigned, use the assigned transform's 'right' axis for movement direction;
                //Project movement direction so movement stays parallel to the ground;
                _velocity += Vector3.ProjectOnPlane(cameraTransform.right, tr.up).normalized *
                             characterInput.GetVerticalMovementInput();
            }
        }

        return _velocity;
    }
}