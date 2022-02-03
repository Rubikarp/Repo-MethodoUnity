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
    Vector2 lastStickDir = Vector2.left;

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
        input.onKick.AddListener(SendKick);
    }

    private float inputThreshold = 0.5f;
    void Update()
    {
        lastStickDir = input.StickMagnitude > inputThreshold ? input.StickDir : lastStickDir;

        if (actualBody != null)
        {
            actualBody.mouv.mouvDir = input.StickMagnitude > inputThreshold ? input.StickDir : Vector2.zero;
        }
    }

    public void SendKick()
    {
        actualBody.kick.DoKick(lastStickDir);
    }

    public void NewPerso()
    {
        ActualBody.Die();
        GameObject go = Instantiate(bodyTemplate, Vector3.zero, Quaternion.identity, transform);
        ActualBody = go.GetComponent<AvatarBody>();
    }
}
