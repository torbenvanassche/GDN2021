using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPlayer : MonoBehaviour
{
    protected void OnTriggerEnter(Collider other)
    {
        Manager.Instance.player.gameObject.transform.SetParent(transform);
    }

    protected void OnTriggerExit(Collider other)
    {
        Manager.Instance.player.gameObject.transform.SetParent(null);
    }
}
