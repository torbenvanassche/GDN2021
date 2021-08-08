using System.Collections;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject playerLocation;
    public float waitAnim = 1.0f;
    public Animation screenAnim;
    public GameObject playerBody;

    //Send player back to start
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(AnimPause());
    }

    private void OnTriggerExit(Collider other)
    {

        //screenAnim.GetComponent<Animator>().enabled = false;
    }

    private void MoveLoc()
    {
        playerLocation.transform.localPosition = new Vector3(0f, 0.3f, 0f);
    }


    IEnumerator AnimPause()
    {
        screenAnim.Play("screenRise");
        yield return new WaitForSeconds(waitAnim);
        MoveLoc();
    }
}
