using UnityEngine;
using System.Collections;

public class DestroyBuildingSystem : MonoBehaviour
{
    [SerializeField] public GameObject currentSlot;
    [SerializeField] public BuildingSlot currentBuildingSlot;

    public void SetSlot(GameObject gameObject)
    {
        currentSlot = gameObject;
        currentBuildingSlot = currentSlot.GetComponent<BuildingSlot>();
    }

    public void ResetSlot()
    {
        currentSlot = null;
    }

    public void CleanSlot()
    {
        currentBuildingSlot._slotIsFree = true;
        currentBuildingSlot.currentBuilding = null;
        currentBuildingSlot.buildingSlotMesh.enabled = true;
        currentBuildingSlot = null;
    }
}
