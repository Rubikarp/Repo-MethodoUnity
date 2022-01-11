using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.GameInput;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputHandler input;
    [SerializeField] private AvatarBody actualBody;

    void Start()
    {
        
    }

    private float inputThreshold = 0.5f;
    void Update()
    {
        if(actualBody != null)
        {
            actualBody.mouv.mouvDir = input.StickMagnitude > inputThreshold ? input.StickDir : Vector2.zero;
        }
    }
}
