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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CutsceneTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator CutsceneTimer()
    {
        //yield return new WaitForSeconds(4);
        spiritAnim.Play("spiritDecent");
        yield return new WaitForSeconds(4);
    }
}
