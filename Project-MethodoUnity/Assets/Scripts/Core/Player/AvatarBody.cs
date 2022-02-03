using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarBody : MonoBehaviour
{
    private bool _alive;
    public bool Alive 
    {
        get { return _alive; }
        set { Alive = value;
            if(value == false)Die();
        }
    }
    public Mouvement mouv;

    private void FixedUpdate()
    {
        
    }

    public void Die()
    {
        mouv.Stop();
    }
}
