using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureCaché : MonoBehaviour
{
    public Mouvement mouv;

    void Update()
    {
        if (Input.GetButton("tkt"))
        {
            StartCoroutine(Dash(mouv.mouvDir, 800));
        }
    }

    public IEnumerator Dash(Vector2 dir, float power)
    {
        yield return null;
        mouv.rb.velocity = dir * power * Time.fixedDeltaTime;
    }
}
