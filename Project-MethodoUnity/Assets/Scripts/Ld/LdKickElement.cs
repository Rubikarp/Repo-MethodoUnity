using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class LdKickElement : MonoBehaviour, IKickable
{
    public UnityEvent interaction;

    public void GetKicked(Vector2 dir, float power = 1f)
    {
        interaction?.Invoke();
    }
}
