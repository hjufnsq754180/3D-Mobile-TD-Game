using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerResourceData _playerResourceData;
    public static bool gameIsOver;

    [SerializeField] private int levelGold;
    [SerializeField] private int levelLives;

    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private GameObject _completeLevelUI;

    private void Awake()
    {
        _playerResourceData.gold = levelGold;
        _playerResourceData.lives = levelLives;
        gameIsOver = false;
    }

    private void Update()
    {
        if (gameIsOver)
        {
            return;
        }

        if (_playerResourceData.lives <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameIsOver = true;
        print("GameOver!");
        _gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        gameIsOver = true;
        _completeLevelUI.SetActive(true);
    }
}
