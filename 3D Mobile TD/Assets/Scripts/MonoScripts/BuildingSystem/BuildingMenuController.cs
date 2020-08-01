using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuildingMenuController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Build Button")]
    [SerializeField] public GameObject attackBuildButton;
    [Space(3)]
    [SerializeField] public GameObject supportBuildButton;

    [Header("Attack Build Button")]
    [SerializeField] private GameObject _attackBuildTower1Button;
    [SerializeField] private GameObject _attackBuildTower2Button;
    [SerializeField] private GameObject _attackBuildTower3Button;
    [SerializeField] private GameObject _attackBuildTower4Button;

    [Header("Attack Build Description")]
    [SerializeField] private GameObject _attackBuildTower1Description;
    [SerializeField] private GameObject _attackBuildTower2Description;
    [SerializeField] private GameObject _attackBuildTower3Description;
    [SerializeField] private GameObject _attackBuildTower4Description;

    [Header("Support Build Button")]
    [SerializeField] private GameObject _supportBuildTower1Button;
    [SerializeField] private GameObject _supportBuildTower2Button;
    [SerializeField] private GameObject _supportBuildTower3Button;
    [SerializeField] private GameObject _supportBuildTower4Button;

    [Header("Support Build Description")]
    [SerializeField] private GameObject _supportBuildTower1Description;
    [SerializeField] private GameObject _supportBuildTower2Description;
    [SerializeField] private GameObject _supportBuildTower3Description;
    [SerializeField] private GameObject _supportBuildTower4Description;


    //Меню постройки зданий
    //TODO: сюда надо в if засовывать все кнопки зданий
    public void ControlAttackBuilgindMenuButtons()
    {
        if (!_attackBuildTower1Button.activeInHierarchy && !_attackBuildTower2Button.activeInHierarchy && !_attackBuildTower3Button.activeInHierarchy && !_attackBuildTower4Button.activeInHierarchy)
        {
            _attackBuildTower1Button.SetActive(true);
            _attackBuildTower2Button.SetActive(true);
            _attackBuildTower3Button.SetActive(true);
            _attackBuildTower4Button.SetActive(true);
            supportBuildButton.SetActive(false);
        }
        else
        {
            DisableMenuButtons();
            supportBuildButton.SetActive(true);
        }
    }

    public void ControlSupportBuilgindMenuButtons()
    {
        if (!_supportBuildTower1Button.activeInHierarchy && !_supportBuildTower2Button.activeInHierarchy && !_supportBuildTower3Button.activeInHierarchy && !_supportBuildTower4Button.activeInHierarchy)
        {
            _supportBuildTower1Button.SetActive(true);
            _supportBuildTower2Button.SetActive(true);
            _supportBuildTower3Button.SetActive(true);
            _supportBuildTower4Button.SetActive(true);
            attackBuildButton.SetActive(false);
        }
        else
        {
            DisableMenuButtons();
            attackBuildButton.SetActive(true);
        }
    }

    //Отключение кнопок постройки зданий
    public void DisableMenuButtons()
    {
        _attackBuildTower1Button.SetActive(false);
        _attackBuildTower2Button.SetActive(false);
        _attackBuildTower3Button.SetActive(false);
        _attackBuildTower4Button.SetActive(false);

        _supportBuildTower1Button.SetActive(false);
        _supportBuildTower2Button.SetActive(false);
        _supportBuildTower3Button.SetActive(false);
        _supportBuildTower4Button.SetActive(false);
    }

    //Методы постройки зданий, передавая нужный аргументы в SetBuilding
    //TODO: Для каждой постройки нужен свой метод, со своими значениями и привязывать их к своим кнопкам

    #region Build Attack Tower

    public void BuildAttackTower1()
    {
        GetComponentInParent<BuildingSlot>().SetBuilding(BuildingManager.instance.attackTower1.towerObject, false, BuildingManager.instance.attackTower1, BuildingManager.instance.playerResourceData);
    }

    public void BuildAttackTower2()
    {
        GetComponentInParent<BuildingSlot>().SetBuilding(BuildingManager.instance.attackTower2.towerObject, false, BuildingManager.instance.attackTower2, BuildingManager.instance.playerResourceData);
    }

    public void BuildAttackTower3()
    {
        GetComponentInParent<BuildingSlot>().SetBuilding(BuildingManager.instance.attackTower3.towerObject, false, BuildingManager.instance.attackTower3, BuildingManager.instance.playerResourceData);
    }

    public void BuildAttackTower4()
    {
        GetComponentInParent<BuildingSlot>().SetBuilding(BuildingManager.instance.attackTower4.towerObject, false, BuildingManager.instance.attackTower4, BuildingManager.instance.playerResourceData);
    }

    #endregion

    #region Build Support Tower

    public void BuildSupportTower1()
    {
        GetComponentInParent<BuildingSlot>().SetBuilding(BuildingManager.instance.supportTower1.towerObject, false, BuildingManager.instance.supportTower1, BuildingManager.instance.playerResourceData);
    }

    public void BuildSupportTower2()
    {
        GetComponentInParent<BuildingSlot>().SetBuilding(BuildingManager.instance.supportTower2.towerObject, false, BuildingManager.instance.supportTower2, BuildingManager.instance.playerResourceData);
    }

    public void BuildSupportTower3()
    {
        GetComponentInParent<BuildingSlot>().SetBuilding(BuildingManager.instance.supportTower3.towerObject, false, BuildingManager.instance.supportTower3, BuildingManager.instance.playerResourceData);
    }

    public void BuildSupportTower4()
    {
        GetComponentInParent<BuildingSlot>().SetBuilding(BuildingManager.instance.supportTower4.towerObject, false, BuildingManager.instance.supportTower4, BuildingManager.instance.playerResourceData);
    }

    #endregion

    //Ниже реализованны метода описания строений, при наведении на кнопку "построить"
    //TODO: нужно будет реализовать для всех зданий
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerEnter == _attackBuildTower1Button)
        {
            _attackBuildTower1Description.SetActive(true);
        }
        if (eventData.pointerEnter == _attackBuildTower2Button)
        {
            _attackBuildTower2Description.SetActive(true);
        }
        if (eventData.pointerEnter == _attackBuildTower3Button)
        {
            _attackBuildTower3Description.SetActive(true);
        }
        if (eventData.pointerEnter == _attackBuildTower4Button)
        {
            _attackBuildTower4Description.SetActive(true);
        }
        //--------------
        if (eventData.pointerEnter == _supportBuildTower1Button)
        {
            _supportBuildTower1Description.SetActive(true);
        }
        if (eventData.pointerEnter == _supportBuildTower2Button)
        {
            _supportBuildTower2Description.SetActive(true);
        }
        if (eventData.pointerEnter == _supportBuildTower3Button)
        {
            _supportBuildTower3Description.SetActive(true);
        }
        if (eventData.pointerEnter == _supportBuildTower4Button)
        {
            _supportBuildTower4Description.SetActive(true);
        }
    }

    //TODO: нужно будет реализовать для всех зданий
    public void OnPointerExit(PointerEventData eventData)
    {
        _attackBuildTower1Description.SetActive(false);
        _attackBuildTower2Description.SetActive(false);
        _attackBuildTower3Description.SetActive(false);
        _attackBuildTower4Description.SetActive(false);

        _supportBuildTower1Description.SetActive(false);
        _supportBuildTower2Description.SetActive(false);
        _supportBuildTower3Description.SetActive(false);
        _supportBuildTower4Description.SetActive(false);
    }
}
