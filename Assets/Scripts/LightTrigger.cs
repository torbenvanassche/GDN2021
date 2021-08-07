using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{

    public GameObject playerLight;

    
    private void OnTriggerEnter(Collider other)
    {
        playerLight.SetActive(true);
    }
}
