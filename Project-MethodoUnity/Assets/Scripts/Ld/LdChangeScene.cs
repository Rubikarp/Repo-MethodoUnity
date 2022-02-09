using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LdChangeScene : MonoBehaviour
{
    [SerializeField] string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneHandler.LoadScene(sceneName);
    }
}
