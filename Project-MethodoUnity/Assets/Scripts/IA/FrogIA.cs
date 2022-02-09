using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogIA : CoreIa
{
    public bool busy = false;

    public float attDur = 0.1f;
    public float cooldown = 0.1f;
    public float attackSpeed = 2f;

    [SerializeField]
    private Animator selfAnimator;

    public override void PlayerDetected(Transform player)
    {
        if (busy) return;
        if (!player.GetComponent<AvatarBody>().Alive) return;

        StartCoroutine(Behavior(player));
    }

    public void KickStop()
    {
        StopAllCoroutines();
        Invoke("Dizzy", 0.3f);
    }

    public void Dizzy()
    {
        busy = false;
    }
    IEnumerator Behavior(Transform player)
    {
        Vector3 dir = player.position- transform.position;

        if (dir.x > 0)
        {
            selfRenderer.flipX = false;
        }
        else
        {
            selfRenderer.flipX = true;
        }

        dir = dir.normalized;
        float dur = attDur;
        busy = true;
        selfAnimator.SetTrigger("Jump");
        yield return null;

        do
        {
            dur -= Time.fixedDeltaTime;
            body.velocity = dir * attackSpeed * Time.fixedDeltaTime;
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
        while (dur > 0.0f);

        
        body.velocity = Vector2.zero;
        yield return new WaitForSeconds(cooldown);
        busy = false;
    }
}
