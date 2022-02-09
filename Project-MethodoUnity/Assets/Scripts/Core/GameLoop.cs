using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameLoop : MonoBehaviour
{
    [Header("Parameter")]
    [SerializeField, Tooltip("x = min / y = sec")] public Vector2Int loopDur;
    public float restingTime = 0f;

    [Header("Parameter")]
    public UnityEvent EndTime;

    [HideInInspector]
    public bool isBreaking = false;

    public static float ComputDur(Vector2Int duration)
    {
        return (float)duration.x * 60.0f + (float)duration.y;
    } 

    void Start()
    {
        restingTime = ComputDur(loopDur);
    }

    void Update()
    {
        if (Input.GetButtonDown("Suicide"))
        {
            EndTime?.Invoke();
            restingTime = ComputDur(loopDur);
        }

        if (!isBreaking)
        {
            if (restingTime > 0.0f)
            {
                restingTime -= Time.deltaTime;
            }
            else
            {
                EndTime?.Invoke();
                restingTime = ComputDur(loopDur);
            }
        }
    }
}
