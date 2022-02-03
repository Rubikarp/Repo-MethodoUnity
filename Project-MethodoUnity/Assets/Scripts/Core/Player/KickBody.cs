using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class KickBody : MonoBehaviour
{
    private Transform self;
    private Rigidbody2D rb;
    private CircleCollider2D coll;

    [Header("data received")]
    public Vector2 kickDir = Vector2.up;

    private void Awake()
    {
        self = transform;
        rb = self.GetComponent<Rigidbody2D>();
        coll = self.GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        
    }

    [ContextMenu("kick right")]
    public void Kicking()
    {
        GetKicked(Vector2.right, 200f);
    }
    public void GetKicked(Vector2 dir, float power)
    {
        kickDir = dir;
        StopAllCoroutines();
        StartCoroutine(Kicked(power));
    }
    public IEnumerator Kicked(float power)
    {
        do
        {
            power -= Time.fixedDeltaTime * 250f;
            rb.velocity = kickDir * power * Time.fixedDeltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        while (rb.velocity.magnitude > 0.05f);

        rb.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        kickDir = Vector2.Reflect(kickDir, collision.contacts[0].normal);
    }
}
