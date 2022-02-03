using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedScreenCamera : MonoBehaviour
{
    private static float viewPortRatio = 16.0f/9.0f;

    [Header("Component")]
    [SerializeField] private Camera camera;
    [SerializeField] private PlayerController player;

    [Header("TODO : rename")]
    [SerializeField] private Transform target;
    private Vector2 viewportPos;

    private void OnEnable()
    {
        PlayerController.Instance.onBodyChange.AddListener(ChangeTarget);
    }


    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
        camera.transform.position = target.position + Vector3.back * 10;
    }

    void Update()
    {
        CheckForCamMouv();
    }

    private void CheckForCamMouv()
    {
        viewportPos = camera.WorldToViewportPoint(target.position);
        Vector2 viewSize = new Vector2(camera.orthographicSize * 2 * (viewPortRatio), camera.orthographicSize * 2);

        if (viewportPos.x > 1.0f)
        {
            MouvCam(viewSize * Vector3.right);
        }
        else if (viewportPos.x < 0)
        {
            MouvCam(viewSize * Vector3.left);
        }
        else if (viewportPos.y > 1)
        {
            MouvCam(viewSize * Vector3.up);
        }
        else if (viewportPos.y < 0)
        {
            MouvCam(viewSize * Vector3.down);
        }
    }

    private void MouvCam(Vector2 mouv)
    {
        camera.transform.position += new Vector3(mouv.x,mouv.y,0);
    }
}
