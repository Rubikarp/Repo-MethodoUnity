using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
public abstract class CoreIa : MonoBehaviour
{
    public CircleCollider2D detectCircle;
    public Rigidbody2D body;
    public SpriteRenderer selfRenderer;

    private void Start()
    {
        selfRenderer = GetComponent<SpriteRenderer>();
    }

    public virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerDetected(collision.transform);
        }
    }

    public virtual void PlayerDetected(Transform player)
    {

    }
}
