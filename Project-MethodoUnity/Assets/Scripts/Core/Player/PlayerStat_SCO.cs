using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStat_new", menuName = "SCO/PlayerStat", order = 1)]
public class PlayerStat_SCO : ScriptableObject
{
    [Header("Stat")]
    [Range(0.0f, 10.0f)] public float speed = 1.0f;

}
