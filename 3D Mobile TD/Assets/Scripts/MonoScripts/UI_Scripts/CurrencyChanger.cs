using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyChanger : MonoBehaviour
{
    [SerializeField] private PlayerResourceData resourceData;

    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI manaText;

    private void OnEnable()
    {
        BuildingSlot.GoldEvent += OnGoldChanged;
        Enemy.GoldEvent += OnGoldChanged;
        EnemyMoving.LivesEvent += OnLivesChanged;
    }

    private void Start()
    {
        OnGoldChanged();
        OnLivesChanged();
    }

    private void OnGoldChanged()
    {
        goldText.text = resourceData.gold.ToString();
    }

    private void OnLivesChanged()
    {
        livesText.text = resourceData.lives.ToString();
    }

    private void OnManaChanged()
    {
        manaText.text = resourceData.gold.ToString();
    }

    private void OnDisable()
    {
        BuildingSlot.GoldEvent -= OnGoldChanged;
        Enemy.GoldEvent -= OnGoldChanged;
        EnemyMoving.LivesEvent -= OnLivesChanged;
    }
}
