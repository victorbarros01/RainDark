using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    public AudioMixer audio;

    public void SetVolume(float volume){
        audio.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }
}
