using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private GameLoop gameLoop;

    [SerializeField]
    private PlayerController ctrlPlayer;

    [SerializeField]
    private GameObject settingsMenu;

    private KeyCode openMenuKey = KeyCode.Escape;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(openMenuKey))
        {
            OpenMenu();
        }
    }

    public void OpenMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        gameLoop.isBreaking = pauseMenu.activeSelf;
        ctrlPlayer.ActualBody.mouv.isBreaking = pauseMenu.activeSelf;
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void BackToGame()
    {
        pauseMenu.SetActive(false);
        gameLoop.isBreaking = false;
        ctrlPlayer.ActualBody.mouv.isBreaking = false;
    }

    public void ActiveButton()
    {
        StartCoroutine(ButtonStill());
    }

    public IEnumerator ButtonStill()
    {
        settingsMenu.SetActive(true);
        yield return new WaitForSeconds(2f);
        settingsMenu.SetActive(false);
    }

}
