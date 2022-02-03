using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Core.GameInput
{
    public class InputHandler : MonoBehaviour
    {
        [Header("Input Map")]
        public InputMap_SCO inputMap;

        //[Header("Stick data")]
        public Vector2 StickLastDir;
        public Vector2 StickDir
        {
            get {return inputMap.StickDir; }
        }
        public Vector2 StickValue
        {
            get {return inputMap.StickValue; }
        }
        public float StickMagnitude
        {
            get { return StickValue.magnitude; }
        }

        [Header("Input Events")]
        public UnityEvent onKick;
        public UnityEvent onSuicide;

        private void Update()
        {
            if (inputMap.isKick)
            {
                onKick?.Invoke();
            }

            if (inputMap.isSuicide)
            {
                onSuicide?.Invoke();
            }
        }
    }
}
