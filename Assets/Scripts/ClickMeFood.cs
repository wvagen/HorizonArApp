using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickMeFood : MonoBehaviour
{
    public Transform foodTransform;
    public MainMenuManager mainMenMan;
    GameObject selectedFood;

    List<GameObject> foodsList = new List<GameObject>();
    bool infoPanelIsDisplayed = false;

    void Start()
    {

        for (int i = 0; i < foodTransform.childCount; i++)
        {
            foodsList.Add(foodTransform.GetChild(i).gameObject);
            foodsList[i].SetActive(false);
        }
        
    }

    void Update()
    {
        if (GetComponent<MeshRenderer>().enabled && !infoPanelIsDisplayed)
        {
            infoPanelIsDisplayed = true;
            mainMenMan.ShowInfoPanel("أنقر على الثلاجة");
        }
    }

    void OnMouseDown()
    {
        EnableRandomObject();
    }

    void EnableRandomObject()
    {
        
        short randIndex = (short)Random.Range(0, foodTransform.childCount);
        if (selectedFood != null) selectedFood.SetActive(false);
        foodsList[randIndex].SetActive(true);
        selectedFood = foodsList[randIndex];

    }

}
