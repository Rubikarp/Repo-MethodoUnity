using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiTime : MonoBehaviour
{
    [Header("R�f�rences")]
    [SerializeField] private Text timeText;
    [SerializeField] private GameLoop levelLoop;

    private void Update()
    {
        if (levelLoop != null) { int leftTimeInt = (int)levelLoop.restingTime; 
        timeText.text = leftTimeInt.ToString();
        }
    }
}
