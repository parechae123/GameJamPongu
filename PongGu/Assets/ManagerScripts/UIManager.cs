using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager UI;
    public TextMeshProUGUI[] scoreText = new TextMeshProUGUI[2];
    public SpriteRenderer[] swordAndShield = new SpriteRenderer[2];
    //0번 왼쪽 플레이어 1번 오른쪽 플레이어
    public static UIManager UIinstance()
    {
        return UI;
    }
    void Awake()
    {
        if (UI == null)
        {
            UI = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (UI != this)
            {
                Destroy(this.gameObject);
            }
        }
    }
    public void ChangeScore(byte plrOneScore,byte plrTwoScore,bool isPlrOne)        //점수 관련 코드
    {
        scoreText[0].text = plrOneScore.ToString();
        scoreText[1].text = plrTwoScore.ToString();
        if (isPlrOne)
        {
            scoreText[0].fontStyle = FontStyles.Underline;      
            scoreText[1].fontStyle = FontStyles.Normal;
            swordAndShield[0].sprite = Resources.Load<Sprite>("swrod");
            swordAndShield[0].transform.rotation = Resources.Load<GameObject>("Swrod").transform.rotation;
            swordAndShield[0].transform.localScale = Resources.Load<GameObject>("Swrod").transform.localScale;
            swordAndShield[1].sprite = Resources.Load<Sprite>("shiled");
            swordAndShield[1].transform.rotation = Resources.Load<GameObject>("Shield").transform.rotation;
            swordAndShield[1].transform.localScale = Resources.Load<GameObject>("Shield").transform.localScale;

        }
        else
        {
            scoreText[1].fontStyle = FontStyles.Underline;
            scoreText[0].fontStyle = FontStyles.Normal;
            swordAndShield[1].sprite = Resources.Load<Sprite>("swrod");
            swordAndShield[1].transform.rotation = Resources.Load<GameObject>("Swrod").transform.rotation;
            swordAndShield[1].transform.localScale = Resources.Load<GameObject>("Swrod").transform.localScale;
            swordAndShield[0].sprite = Resources.Load<Sprite>("shiled");
            swordAndShield[0].transform.rotation = Resources.Load<GameObject>("Shield").transform.rotation;
            swordAndShield[0].transform.localScale = Resources.Load<GameObject>("Shield").transform.localScale;
        }
    }
    public void FirstAttackItem(bool isPlayerOne)
    {
        if (isPlayerOne)
        {
            scoreText[0].fontStyle = FontStyles.Underline;
        }
        else
        {
            scoreText[1].fontStyle = FontStyles.Underline;
        }
    }
}
