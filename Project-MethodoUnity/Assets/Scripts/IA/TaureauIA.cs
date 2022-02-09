using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaureauIA : CoreIa
{
    public bool busy = false;

    public float attDur = 0.5f;
    public float attackSpeed = 6f;

    public override void PlayerDetected(Transform player)
    {
        if (busy) return;

        StartCoroutine(Behavior(player));
    }

    IEnumerator Behavior(Transform player)
    {
        //transform.LookAt(player);
        Vector3 dir = player.position - transform.position;
        float dur = attDur;
        do
        {
            dur -= Time.fixedDeltaTime;
            body.velocity = dir * attackSpeed * Time.fixedDeltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        while (dur > 0.0f);

        body.velocity = Vector2.zero;
        yield return null;
    }
}
