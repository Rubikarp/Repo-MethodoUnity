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

    public void Start()
    {
        positionTransition = cameraMenu.transform.position-new Vector3(0,1,0);
        Debug.Log(positionTransition);
    }


    public void TransitionTo()
    {
        Vector3 endPosition = cameraMenu.transform.position - new Vector3(0, cameraMenu.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y*2, 0);
        Debug.Log(cameraMenu.pixelRect.size.y);
        StartCoroutine(transitionToManager(endPosition));
    }

    private IEnumerator transitionToManager(Vector3 toPosition)
    {
        float timeTransition = 0;
        while(positionTransition != toPosition)
        {
            timeTransition += Time.deltaTime;
            if(timeTransition > 1)
            {
                timeTransition = 1;
            }
            positionTransition = new Vector3(0, toPosition.y * cameraTransitionCuve.Evaluate(timeTransition),-10);
            cameraMenu.transform.position = positionTransition;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForEndOfFrame();
    }


}
