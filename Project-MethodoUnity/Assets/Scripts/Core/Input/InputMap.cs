using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.GameInput
{
    [CreateAssetMenu(fileName = "InputMap_new", menuName = "SCO/InputMap", order = 1)]
    public class InputMap_SCO : ScriptableObject
    {
        [Header("Old Input Sytem")]
        [Header("Axis")]
        [SerializeField] private string axisHori = "Horizontal";
        [SerializeField] private string axisVerti = "Vertical";
        [Header("Button")]
        [SerializeField] private string buttonKick = "Kick";
        [SerializeField] private string buttonHarakiri = "Suicide";

        public Vector2 StickDir
        {
            get
            {
                return new Vector2(Input.GetAxis(axisHori), Input.GetAxis(axisVerti)).normalized;
            }
        }
        public Vector2 StickValue
        {
            get
            {
                return new Vector2(Input.GetAxis(axisHori), Input.GetAxis(axisVerti));
            }
        }
        public bool isSuicide
        {
            get
            {
                return Input.GetButton(buttonHarakiri);
            }
        }
        public bool isKick
        {
            get
            {
                return Input.GetButton(buttonKick);
            }
        }

    }
}
