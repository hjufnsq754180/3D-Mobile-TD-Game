using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class BuildingSlot : MonoBehaviour
{
    public bool _slotIsFree;
    public GameObject currentBuilding;

    private BuildingMenuController buildingMenu;

    [SerializeField] static private Tower _tower;

    //[SerializeField] private GameObject currentSlot;
    [SerializeField] private DestroyBuildingSystem destroyBuildingSystem;

    public MeshRenderer buildingSlotMesh;

    //евент
    public delegate void UpdateDataEventHandler();
    public static event UpdateDataEventHandler UpdateDataEvent;

    public delegate void GoldEventHandler();
    public static event GoldEventHandler GoldEvent;

    private void Start()
    {
        buildingSlotMesh = GetComponentInChildren<MeshRenderer>();
        _slotIsFree = true;
        buildingMenu = FindObjectOfType<BuildingMenuController>();
        destroyBuildingSystem = FindObjectOfType<DestroyBuildingSystem>();
        //destroyBuildingSystem = this.gameObject.GetComponent<DestroyBuildingSystem>(); это при не обычном загрузчике сцены
    }

    //Отключение меню постройки
    private void Update()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape))
        {
            ResetBuildingMenu();
        }
    }

    //Выделение объекта BuildingSlot и включение менюшки с постройками
    //TODO: сделать так, чтоб меню отключалось и нажатием на Ground лувой кнопкой мыши
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && _slotIsFree)
        {
            buildingMenu.transform.GetChild(0).gameObject.SetActive(true);
            buildingMenu.transform.GetChild(1).gameObject.SetActive(false);
            buildingMenu.attackBuildButton.SetActive(true);
            buildingMenu.supportBuildButton.SetActive(true);
            buildingMenu.transform.parent = this.transform;
            buildingMenu.transform.position = this.transform.position;
            buildingMenu.DisableMenuButtons();
        }
        //TODO: доделать панели с апгрейдами и дестроем
        else if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && !_slotIsFree)
        {
            //тут я должен менять у таверов их tower data
            buildingMenu.transform.GetChild(1).gameObject.SetActive(true);
            buildingMenu.transform.GetChild(0).gameObject.SetActive(false);
            buildingMenu.transform.parent = this.transform;
            buildingMenu.transform.position = this.transform.position;
            _tower = GetComponentInChildren<Tower>();
            destroyBuildingSystem.SetSlot(this.gameObject);
        }

        
    }

    public void DestroyTower()
    {
        if (_tower != null)
        {
            _tower.towerData.DestroyTower();
            Destroy(_tower.gameObject);
            ResetBuildingMenu();
            destroyBuildingSystem.CleanSlot();
            GoldEvent?.Invoke();

            print("Tower Destroy");
        }
        else if (_tower == null)
        {
            Debug.LogWarning("Tower is not found");
            return;
        }
        else
        {
            print("какая-то хуйня");
        }
    }
    //TODO: добавить апгрейд для всех 8 зданий
    //TODO: это сатанинскую дичь на 200 строк можно и переписать намного короче, но пока и так работает
    public void UpgradeBuilding()
    {
        if (BuildingManager.instance.playerResourceData.gold >= _tower.towerData.towerUpgradePrice)
        {
            BuildingManager.instance.playerResourceData.gold -= _tower.towerData.towerUpgradePrice;

            if (_tower.towerData == BuildingManager.instance.attackTower1 || _tower.towerData == BuildingManager.instance.upgradeAttackTower1_LEVEL2)
            {
                Debug.Log("Upgrade Attack Tower 1!");
                if (_tower.towerLevel == 1)
                {
                    _tower.towerData = BuildingManager.instance.upgradeAttackTower1_LEVEL2;
                    UpdateDataEvent?.Invoke();
                }
                else if (_tower.towerLevel == 2)
                {
                    _tower.towerData = BuildingManager.instance.upgradeAttackTower1_LEVEL3;
                    UpdateDataEvent?.Invoke();
                }
                else
                {
                    Debug.LogWarning("Maximum Level Tower!");
                    return;
                }
            }

            if (_tower.towerData == BuildingManager.instance.attackTower2 || _tower.towerData == BuildingManager.instance.upgradeAttackTower2_LEVEL2)
            {
                Debug.Log("Upgrade Attack Tower 2!");
                if (_tower.towerLevel == 1)
                {
                    _tower.towerData = BuildingManager.instance.upgradeAttackTower2_LEVEL2;
                    UpdateDataEvent.Invoke();
                }
                else if (_tower.towerLevel == 2)
                {
                    _tower.towerData = BuildingManager.instance.upgradeAttackTower2_LEVEL3;
                    UpdateDataEvent.Invoke();
                }
                else
                {
                    Debug.LogWarning("Maximum Level Tower!");
                    return;
                }
            }

            if (_tower.towerData == BuildingManager.instance.attackTower3 || _tower.towerData == BuildingManager.instance.upgradeAttackTower3_LEVEL2)
            {
                Debug.Log("Upgrade Attack Tower 3!");

                if (_tower.towerLevel == 1)
                {
                    _tower.towerData = BuildingManager.instance.upgradeAttackTower3_LEVEL2;
                    UpdateDataEvent?.Invoke();
                }
                else if (_tower.towerLevel == 2)
                {
                    _tower.towerData = BuildingManager.instance.upgradeAttackTower3_LEVEL3;
                    UpdateDataEvent?.Invoke();
                }
                else
                {
                    Debug.LogWarning("Maximum Level Tower!");
                    return;
                }
            }

            if (_tower.towerData == BuildingManager.instance.attackTower4 || _tower.towerData == BuildingManager.instance.upgradeAttackTower4_LEVEL2)
            {
                Debug.Log("Upgrade Attack Tower 4!");

                if (_tower.towerLevel == 1)
                {
                    _tower.towerData = BuildingManager.instance.upgradeAttackTower4_LEVEL2;
                    UpdateDataEvent?.Invoke();
                }
                else if (_tower.towerLevel == 2)
                {
                    _tower.towerData = BuildingManager.instance.upgradeAttackTower4_LEVEL3;
                    UpdateDataEvent?.Invoke();
                }
                else
                {
                    Debug.LogWarning("Maximum Level Tower!");
                    return;
                }
            }

            if (_tower.towerData == BuildingManager.instance.supportTower1 || _tower.towerData == BuildingManager.instance.upgradeSupportTower1_LEVEL2)
            {
                Debug.Log("Upgrade Support Tower 1!");

                if (_tower.towerLevel == 1)
                {
                    _tower.towerData = BuildingManager.instance.upgradeSupportTower1_LEVEL2;
                    UpdateDataEvent?.Invoke();
                }
                else if (_tower.towerLevel == 2)
                {
                    _tower.towerData = BuildingManager.instance.upgradeSupportTower1_LEVEL3;
                    UpdateDataEvent?.Invoke();
                }
                else
                {
                    Debug.LogWarning("Maximum Level Tower!");
                    return;
                }
            }

            if (_tower.towerData == BuildingManager.instance.supportTower2 || _tower.towerData == BuildingManager.instance.upgradeSupportTower2_LEVEL2)
            {
                Debug.Log("Upgrade Support Tower 2!");

                if (_tower.towerLevel == 1)
                {
                    _tower.towerData = BuildingManager.instance.upgradeSupportTower2_LEVEL2;
                    UpdateDataEvent?.Invoke();
                }
                else if (_tower.towerLevel == 2)
                {
                    _tower.towerData = BuildingManager.instance.upgradeSupportTower2_LEVEL3;
                    UpdateDataEvent?.Invoke();
                }
                else
                {
                    Debug.LogWarning("Maximum Level Tower!");
                    return;
                }
            }

            if (_tower.towerData == BuildingManager.instance.supportTower3 || _tower.towerData == BuildingManager.instance.upgradeSupportTower3_LEVEL2)
            {
                Debug.Log("Upgrade Support Tower 3!");

                if (_tower.towerLevel == 1)
                {
                    _tower.towerData = BuildingManager.instance.upgradeSupportTower3_LEVEL2;
                    UpdateDataEvent?.Invoke();
                }
                else if (_tower.towerLevel == 2)
                {
                    _tower.towerData = BuildingManager.instance.upgradeSupportTower3_LEVEL3;
                    UpdateDataEvent?.Invoke();
                }
                else
                {
                    Debug.LogWarning("Maximum Level Tower!");
                    return;
                }
            }

            if (_tower.towerData == BuildingManager.instance.supportTower4 || _tower.towerData == BuildingManager.instance.upgradeSupportTower4_LEVEL2)
            {
                Debug.Log("Upgrade Support Tower 4!");

                if (_tower.towerLevel == 1)
                {
                    _tower.towerData = BuildingManager.instance.upgradeSupportTower4_LEVEL2;
                    UpdateDataEvent?.Invoke();
                }
                else if (_tower.towerLevel == 2)
                {
                    _tower.towerData = BuildingManager.instance.upgradeSupportTower4_LEVEL3;
                    UpdateDataEvent?.Invoke();
                }
                else
                {
                    Debug.LogWarning("Maximum Level Tower!");
                    return;
                }
            }

            GoldEvent?.Invoke();
        }
    }

    //Метод строительства зданий в специальных слотах с проверкой нужных ресурсов у игрока
    public void SetBuilding(GameObject building, bool useRandomRotation, TowerData towerData, PlayerResourceData resourceData)
    {
        if (resourceData.gold >= towerData.towerBuyPrice)
        {
            if (_slotIsFree)
            {
                Quaternion randomRotation = Quaternion.Euler(new Vector3(0f, (Random.Range(0f, 360f)), 0f));
                if (useRandomRotation)
                {
                    GameObject buildingObj = (Instantiate(building, this.transform.position, randomRotation, this.transform));
                    currentBuilding = buildingObj;
                }
                else
                {
                    GameObject buildingObj = (Instantiate(building, this.transform.position, Quaternion.identity, this.transform));
                    currentBuilding = buildingObj;
                }

                towerData.BuildTower();
                this.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
                this._slotIsFree = false;
                ResetBuildingMenu();
                GoldEvent?.Invoke();
            }
        }
        else
        {
            Debug.LogWarning("Need more resource!");
        }
    }

    //Закрытие меню постройки
    //изначально private
    public void ResetBuildingMenu()
    {
        //в BuildingMenuUI на кнопки апгрейда и дестроя нужно вешать объект прифаба BuildingSlot который на сцене, а не в папке прифабов (иначе будет баг, а это напоминался на тот случай)
        buildingMenu.transform.GetChild(0).gameObject.SetActive(false);
        buildingMenu.transform.GetChild(1).gameObject.SetActive(false);
        buildingMenu.attackBuildButton.SetActive(false);
        buildingMenu.transform.parent = null;
        buildingMenu.transform.position = Vector3.zero;
        buildingMenu.DisableMenuButtons();
        destroyBuildingSystem.ResetSlot();
    }
}
