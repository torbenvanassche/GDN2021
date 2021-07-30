using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingDetector : MonoBehaviour
{
    bool ceilingWasHit = false;

    //Angle limit for ceiling hits;
    public float ceilingAngleLimit = 10f;

    public enum CeilingDetectionMethod
    {
        OnlyCheckFirstContact,
        CheckAllContacts,
        CheckAverageOfAllContacts
    }

    public CeilingDetectionMethod ceilingDetectionMethod;

    //If enabled, draw debug information to show hit positions and hit normals;
    public bool isInDebugMode = false;

    //How long debug information is drawn on the screen;
    float debugDrawDuration = 2.0f;

    Transform tr;

    void Awake()
    {
        tr = transform;
    }

    void OnCollisionEnter(Collision _collision)
    {
        CheckCollisionAngles(_collision);
    }

    void OnCollisionStay(Collision _collision)
    {
        CheckCollisionAngles(_collision);
    }

    //Check if a given collision qualifies as a ceiling hit;
    private void CheckCollisionAngles(Collision _collision)
    {
        float _angle = 0f;

        if (ceilingDetectionMethod == CeilingDetectionMethod.OnlyCheckFirstContact)
        {
            //Calculate angle between hit normal and character;
            _angle = Vector3.Angle(-tr.up, _collision.contacts[0].normal);

            //If angle is smaller than ceiling angle limit, register ceiling hit;
            if (_angle < ceilingAngleLimit)
                ceilingWasHit = true;

            //Draw debug information;
            if (isInDebugMode)
                Debug.DrawRay(_collision.contacts[0].point, _collision.contacts[0].normal, Color.red,
                    debugDrawDuration);
        }

        if (ceilingDetectionMethod == CeilingDetectionMethod.CheckAllContacts)
        {
            for (int i = 0; i < _collision.contacts.Length; i++)
            {
                //Calculate angle between hit normal and character;
                _angle = Vector3.Angle(-tr.up, _collision.contacts[i].normal);

                //If angle is smaller than ceiling angle limit, register ceiling hit;
                if (_angle < ceilingAngleLimit)
                    ceilingWasHit = true;

                //Draw debug information;
                if (isInDebugMode)
                    Debug.DrawRay(_collision.contacts[i].point, _collision.contacts[i].normal, Color.red,
                        debugDrawDuration);
            }
        }

        if (ceilingDetectionMethod == CeilingDetectionMethod.CheckAverageOfAllContacts)
        {
            for (int i = 0; i < _collision.contacts.Length; i++)
            {
                //Calculate angle between hit normal and character and add it to total angle count;
                _angle += Vector3.Angle(-tr.up, _collision.contacts[i].normal);

                //Draw debug information;
                if (isInDebugMode)
                    Debug.DrawRay(_collision.contacts[i].point, _collision.contacts[i].normal, Color.red,
                        debugDrawDuration);
            }

            //If average angle is smaller than the ceiling angle limit, register ceiling hit;
            if (_angle / ((float) _collision.contacts.Length) < ceilingAngleLimit)
                ceilingWasHit = true;
        }
    }

    //Return whether ceiling was hit during the last frame;
    public bool HitCeiling()
    {
        return ceilingWasHit;
    }

    //Reset ceiling hit flags;
    public void ResetFlags()
    {
        ceilingWasHit = false;
    }
}