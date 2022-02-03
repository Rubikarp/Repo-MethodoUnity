using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class Mouvement : MonoBehaviour, IKickable
{
    private Transform self;
    private Rigidbody2D rb;
    private CircleCollider2D coll;

    [Header("Parameter")]
    [SerializeField] private float speed = 200.0f;

    [Header("data received")]
    public Vector2 mouvDir = Vector2.zero;

    private void Awake()
    {
        self = transform;
        rb = self.GetComponent<Rigidbody2D>();
        coll = self.GetComponent<CircleCollider2D>();
    }

    public void ReactToInput()
    {
        rb.velocity = mouvDir * speed * Time.deltaTime;
    }

    public void Stop()
    {
        speed = 0;
        mouvDir = Vector2.zero;
        rb.velocity = Vector2.zero;
    }


    [ContextMenu("kick right")]
    public void Kicking()
    {
        GetKicked(Vector2.right, 200f);
    }
    public void GetKicked(Vector2 dir, float power)
    {
        StopAllCoroutines();
        StartCoroutine(Kicked(dir, power));
    }
    public IEnumerator Kicked(Vector2 dir, float power)
    {
        do
        {
            power -= Time.fixedDeltaTime * 250f;
            rb.velocity = dir * power * Time.fixedDeltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        while (rb.velocity.magnitude > 0.05f);

        rb.velocity = Vector2.zero;
    }
}
