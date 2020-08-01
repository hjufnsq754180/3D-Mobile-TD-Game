using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAllPanelButton : MonoBehaviour
{
    [SerializeField] private List<GameObject> scenePanels;

    //private void Start()
    //{
    //    foreach (var item in scenePanels)
    //    {
    //        item.SetActive(false);
    //    }   
    //}

    public void OffActivePanels()
    {
        foreach (var item in scenePanels)
        {
            item.SetActive(false);
        }
    }

}
