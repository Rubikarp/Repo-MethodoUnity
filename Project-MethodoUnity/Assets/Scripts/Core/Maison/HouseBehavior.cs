using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HouseBehavior : MonoBehaviour, IKickable
{
    public Transform self;
    public List<Transform> mouvPoint;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.2f);
        self.DOMove(mouvPoint[0].position, 2f);
    }

    void Update()
    {
        
    }

    public void GetKicked(Vector2 dir, float power)
    {
        self.DOKill();
    }
}
