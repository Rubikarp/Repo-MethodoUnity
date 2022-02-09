using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class KickBody : MonoBehaviour, IKickable
{
    private Transform self;
    private Rigidbody2D rb;
    private CircleCollider2D coll;

    [Header("data received")]
    public Vector2 kickDir = Vector2.up;
    public UnityEvent kick;

    private void Awake()
    {
        self = transform;
        rb = self.GetComponent<Rigidbody2D>();
        coll = self.GetComponent<CircleCollider2D>();
    }

    [ContextMenu("kick right")]
    public void Kicking()
    {
        GetKicked(Vector2.right, 200f);
    }
    public void GetKicked(Vector2 dir, float power)
    {
        kickDir = dir;
        kick?.Invoke();
        StopAllCoroutines();
        StartCoroutine(Kicked(power));
    }
    public IEnumerator Kicked(float power)
    {
        yield return null;
        rb.velocity = kickDir * power * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        kickDir = Vector2.Reflect(kickDir, collision.contacts[0].normal);
    }
}
