using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public AudioMixer audio;
    public string VolumePName = "Volume";
    public Slider VolumeSlider;

    public void SetVolume(float volume){
        audio.SetFloat(VolumePName, Mathf.Log10(volume) * 20);
    }

    public void GetVolume(){

    audio.GetFloat(VolumePName, out float volume);
    VolumeSlider.SetValueWithoutNotify(Mathf.Pow(10f, volume / 20f));

    }
}
