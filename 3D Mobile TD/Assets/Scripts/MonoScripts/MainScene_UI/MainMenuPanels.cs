using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanels : MonoBehaviour
{
    [SerializeField] private GameObject donatePanel;
    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject farmPanel;
    [SerializeField] private GameObject dailyBonusPanel;
    [SerializeField] private GameObject collectionsPanel;
    [SerializeField] private GameObject achivmentsPanel;
    [SerializeField] private GameObject settingsPanel;


    public void OpenDonatePanel()
    {
        donatePanel.SetActive(true);
    }
    public void OpenUpgradePanel()
    {
        upgradePanel.SetActive(true);
    }
    public void OpenShopPanel()
    {
        shopPanel.SetActive(true);
    }
    public void OpenFarmPanel()
    {
        farmPanel.SetActive(true);
    }
    public void OpenDailyBonusPanel()
    {
        dailyBonusPanel.SetActive(true);
    }
    public void OpenCollectionsPanel()
    {
        collectionsPanel.SetActive(true);
    }
    public void OpenAchivmentsPanel()
    {
        achivmentsPanel.SetActive(true);
    }
    public void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }


}
