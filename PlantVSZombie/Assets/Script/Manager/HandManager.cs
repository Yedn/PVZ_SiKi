using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public List<Plant> plantPrefabList;
    private Plant currentPlant;
    private bool handHasPlant=false;
    public static HandManager instance { get; private set; }
    private void Awake()
    {
        instance = this; 
    }

    private void Update()
    {
        FollowCursor();
    }
    public bool AddPlantInHead(PlantType plantType)
    {
        if (currentPlant != null) 
        {
            return false;
        };
        Plant plantPrefab = GetPlantPrefab(plantType);
        if (plantPrefab == null)
        {
            
            return false;
        }
        currentPlant = GameObject.Instantiate(plantPrefab);
        return true;
    }   

    private Plant GetPlantPrefab(PlantType plantType)
    {
        foreach(var plant in plantPrefabList)
        {
            if (plant.plantType == plantType) return plant;
        }
        return null;
    }

    private void FollowCursor()
    {
        if (currentPlant == null)
        {
            return;
        }
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        currentPlant.transform.position = mouseWorldPosition;
    }

    public void OnCellClick(Cell cell)
    {
        if (currentPlant ==  null) 
        {
            return; 
        }
        bool isSuccess =  cell.AddPlant(currentPlant);
        if (isSuccess)
        {
            currentPlant = null;
        }

    }
}
