using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
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

    [SerializeField]
    private Text textResolution;
    private int resolutionChoosen;

    public Resolution[] allResolutions;

    private bool isFullScreen = false;

    public AudioMixer mainAudio;
    private float musicVolume;

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

        allResolutions = Screen.resolutions;
        textResolution.text = Screen.currentResolution.width.ToString() + "*" + Screen.currentResolution.height.ToString();
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

        resolutionChoosen++;
        if(resolutionChoosen > allResolutions.Length)
        {
            resolutionChoosen = 0;
        }

        Screen.SetResolution(allResolutions[resolutionChoosen].width, allResolutions[resolutionChoosen].height, Screen.fullScreen);
        textResolution.text = allResolutions[resolutionChoosen].width.ToString() + "*" + allResolutions[resolutionChoosen].height.ToString();
    }

    public void AddVolume()
    {
        musicVolume++;
        mainAudio.SetFloat("Master", musicVolume != 0 ? Mathf.Log10(musicVolume) * 20 : -80);

        if (musicVolume > 9)
        {
            musicVolume = 9;
        }

        textVolume.text = (musicVolume).ToString();
    }

    public void ReduceVolume()
    {
        musicVolume--;
        mainAudio.SetFloat("Master", musicVolume != 0 ? Mathf.Log10(musicVolume) * 20 : -80);

        if(musicVolume < 0)
        {
            musicVolume = 0;
        }

        textVolume.text = (musicVolume).ToString();
        Debug.Log(musicVolume);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Maison");
    }

    public void BackToMain() 
    {
        menuTransition.TransitionToUpDowwn(false);
        chooseScene = sceneEnum.mainMenu;
    }
}
