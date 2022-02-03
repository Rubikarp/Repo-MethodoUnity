using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Core.GameInput;

[System.Serializable]
public class TransformEvent : UnityEvent<Transform> { }

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private InputHandler input;

    public TransformEvent onBodyChange;
    [SerializeField] private AvatarBody actualBody;
    [Space(10)]
    [SerializeField] private GameObject bodyTemplate;

    public AvatarBody ActualBody
    {
        get { return actualBody; }
        set 
        { 
            actualBody = value;
            onBodyChange?.Invoke(actualBody.transform);
        }
    }

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

    public void NewPerso()
    {
        ActualBody.Die();
        GameObject go = Instantiate(bodyTemplate, Vector3.zero, Quaternion.identity, transform);
        ActualBody = go.GetComponent<AvatarBody>();
    }
}
