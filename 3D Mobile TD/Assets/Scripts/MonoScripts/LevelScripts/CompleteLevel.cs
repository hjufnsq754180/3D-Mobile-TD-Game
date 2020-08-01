using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    [SerializeField] private SceneFader _sceneFader;
    [SerializeField] private string menuSceneName = "MainMenu";

    [SerializeField] private string levelSelectScene = "LevelSelect";
    [SerializeField] private int levelToUnlock = 2;

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        _sceneFader.FadeTo(levelSelectScene);
    }

    public void Menu()
    {
        _sceneFader.FadeTo(menuSceneName);
    }
}
