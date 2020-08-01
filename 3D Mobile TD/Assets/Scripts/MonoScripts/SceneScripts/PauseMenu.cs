using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _ui;

    [SerializeField] private SceneFader sceneFader;

    [SerializeField] private string menuSceneName = "MainMenu";

    private void Update()
    {
        if (GameManager.gameIsOver)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        _ui.SetActive(!_ui.activeSelf);

        if (_ui.activeSelf)
        {
            Time.timeScale = 0f;

        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(menuSceneName);
    }
}
