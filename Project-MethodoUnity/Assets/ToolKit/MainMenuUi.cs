using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuUi : MonoBehaviour
{

    UIDocument mDoc;

    // Start is called before the first frame update
    private void Awake()
    {
        mDoc = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        var root = mDoc.rootVisualElement;
        VisualElement mainMenu = root.Q<VisualElement>("MainMenu");

        VisualElement settingsMenu = root.Q<VisualElement>("SettingsElement");

        Button Settings = root.Q<Button>("Settings");
        Settings.clicked += () =>
        {
            Debug.Log("test");
            mainMenu.style.display = DisplayStyle.None;
            settingsMenu.style.display = DisplayStyle.Flex;
        };

        Button Quit = root.Q<Button>("Quit");
        Quit.clicked += () =>
        {
            Application.Quit();
        };
    }
}
