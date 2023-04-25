using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelections : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitsSelected = new List<GameObject>();

    private static UnitSelections _instance;
    public static UnitSelections Instance { get {return _instance;} }

    private void Awake()
    {
        // if an instance of this already exists and it isnt this one
        if (_instance != null && _instance != this)
        {
            // destroy this instance
            Destroy(this.gameObject);
        }
        else
        {
            // make this the instance
            _instance = this;
        }
    }

    public void ClickSelect(GameObject unitToAdd)
    {
        DeSelectAll();
        unitsSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
    }
    
    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if (!unitsSelected.Contains(unitToAdd))
        {
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            
            unitsSelected.Remove(unitToAdd);
        }
    }
    
    public void DragSelect(GameObject unitToAdd)
    {
        
    }

    public void DeSelectAll()
    {
        foreach (var unit in unitsSelected)
        {
            unit.transform.GetChild(0).gameObject.SetActive(false);
        }
        unitsSelected.Clear();
    }

    public void DeSelect(GameObject unitToDeselect)
    {
        
    }
}
