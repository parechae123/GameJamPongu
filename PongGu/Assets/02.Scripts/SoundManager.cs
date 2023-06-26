using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class SoundManager : MonoBehaviour
{
    static SoundManager soundManager;
    public AudioClip[] bgm;
    public AudioSource bgSound;
    public AudioMixer mixer;
    // Start is called before the first frame update
    void Awake()
    {
        if(soundManager == null)
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
            if(arg0.name == bgm[i].name)
            {
                BGMSound(bgm[i]);
            }

        }
    }
    public void SFXVoulum(float val)
    {
        mixer.SetFloat("BGMSoundVolum", Mathf.Log10(val) * 20);
    }
    public void BGMVoulum(float val)
    {
        mixer.SetFloat("SFXSoundVolum", Mathf.Log10(val) * 20);
    }
    public void BGMSound(AudioClip clip)
    {
        bgSound.clip = clip;
        bgSound.outputAudioMixerGroup = mixer.FindMatchingGroups("BGMSoundVolum")[0];
        bgSound.loop = true;
        bgSound.Play();
    }
    public void SFXSound(string name, AudioClip clip)
    {
        GameObject go = new GameObject(name + "Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFXSoundVolum")[0];
        audioSource.Play();

        Destroy(go, clip.length);
    }
}
