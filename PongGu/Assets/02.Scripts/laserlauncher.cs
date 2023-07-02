using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class laserlauncher : MonoBehaviour
{
    public static laserlauncher laserL;
    public bool laserLauncher;
    public bool updateLim = true;
    public int num;
    private bool dksl = true;
    // Start is called before the first frame update
    private void Awake()
    {
        if(laserL == null)
        {
            laserL = this;
        }
    }
    void Start()
    {
        num = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (dksl)
        {
            StartCoroutine(Num());
            dksl = false;
        }
        if (num == 1)
        {
            laserLauncher = true;
            Debug.Log("num = 1");
        }
        else if (num == 0)
        {
            laserLauncher = false;
            Debug.Log("num = 0");
        }
        

    }
    IEnumerator Num()
    {
        Debug.Log("¼ýÀÚ ·£´ý");
        yield return new WaitForSeconds(3.5f);
        laserL.num = Random.Range(0, 2);
        dksl = true;
    }
}
