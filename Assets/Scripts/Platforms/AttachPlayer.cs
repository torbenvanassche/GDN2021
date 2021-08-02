using UnityEngine;

public class AttachPlayer : MonoBehaviour
{
    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Manager.Instance.player.gameObject.transform.SetParent(transform);
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Manager.Instance.player.gameObject.transform.SetParent(null);
        }
    }
}
