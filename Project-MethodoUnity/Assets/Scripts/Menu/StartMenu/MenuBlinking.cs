using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBlinking : MonoBehaviour
{
    [SerializeField]
    private Image imageThatBlink; //Image that will blink
    [SerializeField]
    private AnimationCurve CurveToBlink; //Curve to define the alpha of image during time

    private Color alphaToBlink;
    private float timeToBlink = 1f;

    private bool alphaSupp; //Check if we need to add value of Alpha
    private bool alphaInf; //Check if we need to decrease value of Alpha

    public void Start()
    {
        alphaToBlink = imageThatBlink.color;
    }

    public void Update()
    {
        if(timeToBlink >= CurveToBlink[CurveToBlink.keys.Length-1].time)
        {
            alphaInf = true;
            alphaSupp = false;
        }

        if(timeToBlink <= 0)
        {
            alphaSupp = true;
            alphaInf = false;
        }

        if (alphaSupp)
        {
            timeToBlink += Time.deltaTime;
        }

        if (alphaInf)
        {
            timeToBlink -= Time.deltaTime;
        }

        alphaToBlink.a = CurveToBlink.Evaluate(timeToBlink);
        imageThatBlink.color = alphaToBlink;
    }
}
