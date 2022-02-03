using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HighKick : MonoBehaviour
{
    public float range = 2f;
    public float size = 2f;
    [Space(10)]
    public float power = 200f;

    [Header("Références")]
    [SerializeField] private Animator selfRenderer;

    public void DoKick(Vector2 kickDir)
    {
        selfRenderer.SetTrigger("IsKicking");
        Collider2D[] collidersHit = Physics2D.OverlapCircleAll((Vector2)transform.position + kickDir * range, size);
        if(collidersHit.Length > 0)
        {
            for (int i = 0; i < collidersHit.Length; i++)
            {
                IKickable kickTarget = collidersHit[i].GetComponent<IKickable>();
                if (kickTarget != null)
                {
                    kickTarget.GetKicked(kickDir, power);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Handles.DrawWireDisc(transform.position + Vector3.one * range,Vector3.forward, size);
    }
}
