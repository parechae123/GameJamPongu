using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class FadeOut : MonoBehaviour
{
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOutImg());
    }

    // Update is called once per frame
    public IEnumerator FadeOutImg()
    {
        yield return new WaitForSeconds(2f);
        image.DOFade(0, 2f);
        yield return new WaitForSeconds(2f);
        image.DOFade(1, 1f);
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
