using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public Slider sfxSlider;
    public Slider bgmSlider;
    public SoundManager soundManager;
    public AudioMixer mixer;

    public void StartGame()
    {
        SceneManager.LoadScene("Stadium");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}