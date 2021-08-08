using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneOne : MonoBehaviour
{

    public Camera cinemaCam;
    public GameObject cinemaPlayer;

    public Animation spiritAnim;
    public Animation petAnim;
    public Animation spiritAnimTwo;

    public Animation spiritAnimIdle;
    public Animation petAnimIdle;

    


    IEnumerator CutsceneTimer()
    {
        spiritAnim.Play("spiritDecent");
        yield return new WaitForSeconds(5);
    }
}
