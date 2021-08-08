using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource SFX;
    
    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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
