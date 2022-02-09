using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureCaché : MonoBehaviour
{
    public Mouvement mouv;

    void Update()
    {
        if (/*Input.GetButton("tkt")*/false)
        {
            StartCoroutine(Dash(mouv.mouvDir, 800));
        }
    }

    public IEnumerator Dash(Vector2 dir, float power)
    {
        float dur = 0.3f;
        do
        {
            dur -= Time.deltaTime;
            mouv.rb.velocity = dir * power * Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();

        }
        while (dur > 0);
    }
}
