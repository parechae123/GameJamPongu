using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{
    public GameObject optionPanel;
    public GameObject gameModePanel;
    public Button[] firstButton = new Button[3];
    public Button[] ModeButton = new Button[4];
    public AudioClip selectSound;
    public Image image;

    public void StartGameOpen()
    {
        SoundManager.soundManager.SFXSound("Select", selectSound);
        gameModePanel.SetActive(true);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(gameModePanel.transform.DOScale(new Vector2(0.8f, 0.8f), 0.1f));
        sequence.Append(gameModePanel.transform.DOScale(new Vector2(0.7f, 0.7f), 0.1f));
        AllOpenButtonFalse();
    }
    public void StartClose()
    {
        SoundManager.soundManager.SFXSound("Select", selectSound);
        StartCoroutine(StartWindowClose());

    }
    public void OptionsOpen()
    {
        SoundManager.soundManager.SFXSound("Select", selectSound);
        optionPanel.SetActive(true);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(optionPanel.transform.DOScale(new Vector2(0.8f, 0.8f), 0.1f));
        sequence.Append(optionPanel.transform.DOScale(new Vector2(0.7f, 0.7f), 0.1f));
        AllOpenButtonFalse();
    }
    public void OptionsClose()
    {
        SoundManager.soundManager.SFXSound("Select", selectSound);
        StartCoroutine(OptionCloseTime());

    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void TrapMode()
    {
        StartButtonSelec();
        SoundManager.soundManager.SFXSound("Select", selectSound);
        StartCoroutine(NextSceneTrap());
    }
    public void ItemMode()
    {
        StartButtonSelec();
        SoundManager.soundManager.SFXSound("Select", selectSound);
        StartCoroutine(NextSceneItem());
    }
    public void MixMode()
    {
        StartButtonSelec();
        SoundManager.soundManager.SFXSound("Select", selectSound);
        StartCoroutine(NextSceneMix());
    }
    public IEnumerator NextSceneTrap()
    {
        AllCloseButtonTrue();
        image.gameObject.SetActive(true);
        image.DOFade(1, 1f);
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene("StartScene");

    }
    public IEnumerator NextSceneMix()
    {
        AllCloseButtonTrue();
        image.gameObject.SetActive(true);
        image.DOFade(1, 1f);
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene("StartScene");

    }
    public IEnumerator NextSceneItem()
    {
        AllCloseButtonTrue();
        image.gameObject.SetActive(true);
        image.DOFade(1, 1f);
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene("Stadium");
    }
    public IEnumerator OptionCloseTime()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(optionPanel.transform.DOScale(new Vector2(0.0001f, 0.0001f), 0.1f));
        yield return new WaitForSeconds(0.1f);
        optionPanel.SetActive(false);
        AllCloseButtonTrue();
    }
    public IEnumerator StartWindowClose()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(gameModePanel.transform.DOScale(new Vector2(0.0001f, 0.0001f), 0.1f));
        yield return new WaitForSeconds(0.1f);
        gameModePanel.SetActive(false);
        AllCloseButtonTrue();

    }
    public void AllCloseButtonTrue()
    {
        for (int i = 0; i < firstButton.Length; i++)
        {
            firstButton[i].interactable = true;
        }
    }
    public void AllOpenButtonFalse()
    {
        for (int i = 0; i < firstButton.Length; i++)
        {
            firstButton[i].interactable = false;
        }
    }
    public void StartButtonSelec()
    {
        for (int i = 0; i < ModeButton.Length; i++)
        {
            ModeButton[i].interactable = false;
        }
    }
    
    
}