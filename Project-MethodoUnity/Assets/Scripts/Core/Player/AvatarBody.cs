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

    private void FixedUpdate()
    {
        if (Alive)
        {
            mouv.ReactToInput();
        }
    }

    public void Die()
    {
        mouv.Stop();
    }
}
