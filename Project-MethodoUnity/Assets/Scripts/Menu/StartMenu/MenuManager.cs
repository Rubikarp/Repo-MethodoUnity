using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public enum sceneEnum
    {
        startMenu,
        mainMenu
    }

    [Header("Script Références")]
    [SerializeField]
    private MenuTransition menuTransition;

    [Header("Object Références")]
    [SerializeField]
    private GameObject startCanvasMenu;
    [SerializeField]
    private GameObject mainCanvasMenu;


    private sceneEnum chooseScene;

    void Start()
    {
        chooseScene = sceneEnum.startMenu;
    }

    // Update is called once per frame
    void Update()
    {
        switch (chooseScene)
        {
            case sceneEnum.startMenu:
                if (Input.anyKey)
                {
                    chooseScene = sceneEnum.mainMenu;
                    menuTransition.TransitionTo();
                }
                break;
            case sceneEnum.mainMenu:

                break;
            default:
                break;
        }

    }
}
