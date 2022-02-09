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

    private bool CD = true;
    public void CD2()
    {
        CD = true;
    }
    private void Start()
    {
        CD = true;
        selfRenderer = GetComponent<SpriteRenderer>();
    }

    public virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerDetected(collision.transform);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && CD)
        {
            if (collision.gameObject.GetComponent<AvatarBody>().Alive)
            {

            GameLoop.Instance.EndTime?.Invoke();
            GameLoop.Instance.restingTime = GameLoop.ComputDur(GameLoop.Instance.loopDur);

            CD = false;
            Invoke("CD2", 0.3f);
            }
        }
    }

    public virtual void PlayerDetected(Transform player)
    {

    }
}
