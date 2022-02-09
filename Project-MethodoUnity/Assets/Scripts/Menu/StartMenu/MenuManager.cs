using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    [SerializeField]
    private GameObject OnFullScreen;
    [SerializeField]
    private GameObject OffFullScreen;

    private sceneEnum chooseScene;

    [SerializeField]
    private Text textVolume;

    private bool isFullScreen = false;

    void Start()
    {
        chooseScene = sceneEnum.startMenu;
        isFullScreen = Screen.fullScreen;

        Screen.fullScreen = isFullScreen;
        if (isFullScreen)
        {
            OnFullScreen.SetActive(true);
            OffFullScreen.SetActive(false);
        }
        else
        {
            OnFullScreen.SetActive(false);
            OffFullScreen.SetActive(true);
        }
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
                    chooseScene = sceneEnum.mainMenu;
                }
                break;
            default:
                break;
        }

    }

    public void SetFullScreen()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
        if (isFullScreen)
        {
            OnFullScreen.SetActive(true);
            OffFullScreen.SetActive(false);
        }
        else
        {
            OnFullScreen.SetActive(false);
            OffFullScreen.SetActive(true);
        }
    }

    public void SetResolution()
    {
        Screen.SetResolution(640, 480, Screen.fullScreen);
    }

    public void AddVolume()
    {

    }

    public void ReduceVolume()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("Maison");
    }

     
}
