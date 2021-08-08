using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStop : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        Controls.Instance.Input.Disable();
        //player.GetComponent<Mover>() = false;
    }
}
