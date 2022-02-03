using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Mouvement : MonoBehaviour
{
    private Transform self;
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    [Header("Parameter")]
    [SerializeField] private float speed = 2.0f;

    [Header("data received")]
    public Vector2 mouvDir = Vector2.zero;

    private void Awake()
    {
        self = transform;
        rb = self.GetComponent<Rigidbody2D>();
        coll = self.GetComponent<BoxCollider2D>();
    }

    private void Move()
    {
        rb.velocity = mouvDir * speed * Time.deltaTime;
    }

    public void Stop()
    {
        speed = 0;
        mouvDir = Vector2.zero;
        rb.velocity = Vector2.zero;
    }
}
