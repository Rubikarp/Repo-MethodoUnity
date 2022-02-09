using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighKick : MonoBehaviour
{
    public float range = 2f;
    public float size = 2f;
    [Space(10)]
    public float power = 200f;
    [Space(10)]
    public float cooldDown = 0.2f;
    public bool can = true;

    [Header("Références")]
    [SerializeField] private Animator selfRenderer;
    [SerializeField] private AudioSource sound;

    public void CD()
    {
        can = true;
    }
    public void DoKick(Vector2 kickDir)
    {
        if (!can) return;

        selfRenderer.SetTrigger("IsKicking");
        Collider2D[] collidersHit = Physics2D.OverlapCircleAll((Vector2)transform.position + kickDir * range, size);
        if(collidersHit.Length > 0)
        {
            for (int i = 0; i < collidersHit.Length; i++)
            {
                if (!collidersHit[i].isTrigger) 
                {
                    IKickable kickTarget = collidersHit[i].GetComponent<IKickable>();
                    if (kickTarget != null )
                    {
                        kickTarget.GetKicked(kickDir, power);
                        sound.Play();
                        can = false;
                        Invoke("CD", cooldDown);
                    }
                }
            }
        }
    }
}
