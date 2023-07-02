using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class LaserX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (laserlauncher.laserL.laserLauncher && laserlauncher.laserL.updateLim)
        {
            Debug.Log("반응X");
            StartCoroutine(LaserLauncherX());
            laserlauncher.laserL.updateLim = false;
        }
    }
    public IEnumerator LaserLauncherX()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 3; i++)
        {
            gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().DOFade(1, 0.25f);
            yield return new WaitForSeconds(0.25f);
            gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().DOFade(0, 0.25f);
            yield return new WaitForSeconds(0.25f);
        }
        Debug.Log("레이저X");
        laserlauncher.laserL.updateLim = true;
    }
}
