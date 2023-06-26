using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreRegister : MonoBehaviour
{
    public byte boardIndex;
    void Start()
    {
        UIManager.UIinstance().scoreText[boardIndex] = GetComponent<TextMeshProUGUI>();
        Debug.Log(string.Empty);
    }
}
