using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTransition : MonoBehaviour
{
    [SerializeField]
    private Camera cameraMenu;
    [SerializeField]
    private AnimationCurve cameraTransitionCuve;

    private Vector3 positionTransition;


    public void TransitionToUpDowwn(bool down)
    {
        if (down)
        {
            Vector3 endPosition = -new Vector3(0, Mathf.Abs(cameraMenu.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y * 2), 0);
            Debug.Log(endPosition);
            StartCoroutine(transitionToManager(endPosition));
        }
        else
        {
            Vector3 endPosition = new Vector3(0, Mathf.Abs(cameraMenu.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y * 2), 0);
            Debug.Log(endPosition);
            StartCoroutine(transitionToManager(endPosition));
        }

    }


    private IEnumerator transitionToManager(Vector3 toPosition)
    {
        float timeTransition = 0;
        Vector3 startPosition = cameraMenu.transform.position;
        while (positionTransition != toPosition)
        {
            timeTransition += Time.deltaTime;
            if(timeTransition > 1)
            {
                timeTransition = 1;
            }
            
            positionTransition = startPosition + new Vector3(0, toPosition.y * cameraTransitionCuve.Evaluate(timeTransition), -10);
            
            cameraMenu.transform.position = positionTransition;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForEndOfFrame();
    }


}
