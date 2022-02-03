using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public enum sceneEnum
    {
        startMenu,
        mainMenu,
        settings
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

    public void OnPressedSettings()
    {
        menuTransition.TransitionToUpDowwn(true);
        chooseScene = sceneEnum.settings;
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
                    menuTransition.TransitionToUpDowwn(true);
                }
                break;
            case sceneEnum.mainMenu:

                break;
            case sceneEnum.settings:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    menuTransition.TransitionToUpDowwn(false);
                }
                break;
            default:
                break;
        }

    }

    public void SetFullScreen()
    {

    }

    public void SetResolution()
    {

    }

     
}
