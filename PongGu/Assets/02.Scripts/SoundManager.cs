using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;
    public AudioClip[] bgm;
    public AudioSource bgSound;
    public AudioMixer mixer;



    void Awake()
    {
        if (soundManager == null)
        {
            soundManager = this;
            DontDestroyOnLoad(soundManager);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }
    public void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            if (arg0.name == bgm[i].name)
            {
                BGMSound(bgm[i]);
            }

        }
    }

    public void BGMSound(AudioClip clip)
    {
        bgSound.clip = clip;
        bgSound.outputAudioMixerGroup = mixer.FindMatchingGroups("BGMSoundVolume")[0];
        bgSound.loop = true;
        bgSound.Play();
    }
    public void SFXSound(string name, AudioClip clip)
    {
        GameObject go = new GameObject(name + "Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.playOnAwake = false;
        audioSource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFXSoundVolume")[0];
        audioSource.Play();

        Destroy(go, clip.length);
    }



    public void SetBGMVolume(float volume)
    {
        if (volume > 0)
        {
            mixer.SetFloat("BGMSoundVolume", Mathf.Log10(volume) * 20);

        }
        else
        {
            mixer.SetFloat("BGMSoundVolume", Mathf.Log10(-80));
        }
    }

    public void SetSFXVolume(float volume)
    {
        if (volume > 0)
        {
            mixer.SetFloat("SFXSoundVolume", Mathf.Log10(volume) * 20);
        }
        else
        {
            mixer.SetFloat("SFXSoundVolume", Mathf.Log10(-80));
        }
    }

}
