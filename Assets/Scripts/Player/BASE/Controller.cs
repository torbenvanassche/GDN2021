using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    //Getters;
    public abstract Vector3 GetVelocity();

    public abstract Vector3 GetMovementVelocity();

    public abstract bool IsGrounded();

    //Events;
    public delegate void VectorEvent(Vector3 v);

    public VectorEvent OnJump;
    public VectorEvent OnLand;

    public delegate void Event();

    public Event OnDodge;

    public delegate void DashEvent();

    public DashEvent OnDashstart;

    public DashEvent OnDashend;

    public delegate void AttackEvent();

    public AttackEvent OnAttackStart;
    public AttackEvent OnAttackEnd;

    public virtual bool IsRunning()
    {
        return false;
    }

    public virtual bool IsDodging()
    {
        return false;
    }
}