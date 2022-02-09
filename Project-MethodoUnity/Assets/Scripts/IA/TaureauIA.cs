using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaureauIA : CoreIa
{
    public bool busy = false;
    public bool stun = false;

    public float cooldown = 0.1f;
    public float attackSpeed = 2f;

    public Animator selfAnimator;

    public override void PlayerDetected(Transform player)
    {
        if (busy || stun) return;
        if (!player.GetComponent<AvatarBody>().Alive) return;

        StartCoroutine(Behavior(player));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        busy = false;
    }

    public void KickStop()
    {
        StopAllCoroutines();
        Invoke("Dizzy", 0.3f);
    }

    public void Dizzy()
    {
        busy = false;
        stun = false;
    }

    

    IEnumerator Behavior(Transform player)
    {
        Vector3 dir = player.position - transform.position;

        if(dir.x > 0)
        {
            selfRenderer.flipX = false;
        }
        else
        {
            selfRenderer.flipX = true;
        }

        dir = dir.normalized;
        busy = true;
        selfAnimator.SetBool("Charge", true);
        yield return new WaitForSeconds(0.3f);

        do
        {
            body.velocity = dir * attackSpeed * Time.fixedDeltaTime;
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
        while (busy);
        stun = true;
        body.velocity = Vector2.zero;
        yield return new WaitForSeconds(cooldown);
        stun = false;
        selfAnimator.SetBool("Charge", false);
    }
}
