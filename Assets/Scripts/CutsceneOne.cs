using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneOne : MonoBehaviour
{

    public Camera cinemaCam;
    public GameObject playerPet;
    public GameObject pet;
    public GameObject dialogue;
    public GameObject moveStop;

    public Animation spiritAnim;
    public Animation petAnim;


    void Start()
    {
        StartCoroutine(CutsceneTimer());
    }


    IEnumerator CutsceneTimer()
    {
        //yield return new WaitForSeconds(4);
        spiritAnim.Play("spiritDecent");
        yield return new WaitForSeconds(5);
        dialogue.SetActive(true);
        yield return new WaitForSeconds(10);
        pet.SetActive(true);
        petAnim.Play("pullApart");
        yield return new WaitForSeconds(5);
        playerPet.SetActive(true);
        pet.SetActive(false);
        moveStop.SetActive(false);
        Controls.Instance.Input.Enable();
    }
}
