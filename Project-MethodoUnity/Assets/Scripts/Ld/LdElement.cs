using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Flags]
public enum EventCondition
{
    enter = 1,
    exit = 2,
}

public class LdElement : MonoBehaviour
{
    public EventCondition useCase;
    public UnityEvent enter;
    public UnityEvent exit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (useCase.HasFlag(EventCondition.enter) 
            && !collision.isTrigger 
            && collision.CompareTag("Player"))
            enter?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (useCase.HasFlag(EventCondition.enter) 
            && !collision.isTrigger 
            && collision.CompareTag("Player"))
            exit?.Invoke();
    }
}
