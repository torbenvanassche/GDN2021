using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource SFX;

    public GameObject menu;
    public GameObject cutsceneGroup;
    
/*    public void SwapScenes(string sceneName)
    {
        //SceneManager.LoadScene(sceneName);
        menuActivator();
    }*/


    //Turns off main menu graphics
    public void menuActivator()
    {
        menu.SetActive(false);
        cutsceneGroup.SetActive(true);
    }

    public void VolumeChange(float volume)
    {
        mixer.SetFloat("Volume", volume);
    }

    public void PlaySoundOnce(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}
