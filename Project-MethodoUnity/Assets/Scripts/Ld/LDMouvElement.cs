using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LDMouvElement : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;

    public void MoveToEnd(bool end)
    {
        transform.DOLocalMove(end ? endPos : startPos, 1f).SetEase(Ease.InOutCirc);
    }
}
