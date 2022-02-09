using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarBody : MonoBehaviour
{
    [SerializeField] private bool _alive = true;
    public bool Alive 
    {
        get { return _alive; }
        set { _alive = value; }
    }
    public Mouvement mouv;
    public HighKick kick;

    [SerializeField] private GameObject kickVisual;

    private void FixedUpdate()
    {
        if (Alive)
        {
            mouv.ReactToInput();
            kickVisual.transform.position = (Vector2)transform.position + mouv.mouvDir * kick.range;
        }
    }

    public void Die()
    {
        Destroy(kickVisual);
        Alive = false;
        mouv.Stop();
    }
}
