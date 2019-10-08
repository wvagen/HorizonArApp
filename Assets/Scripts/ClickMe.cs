using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickMe : MonoBehaviour
{
    public GameObject[] foods;
    GameObject selectedFood;

    void Update()
    {
        Debug.Log("Test");
    }

    void OnMouseDown()
    {
        if (EventSystem.current.gameObject.tag == "Table")
        {
            short randomIndex = (short) Random.Range(0, foods.Length);
            if (selectedFood != null) selectedFood.SetActive(false);
            foods[randomIndex].SetActive(true);
            selectedFood = foods[randomIndex];
        }
    }
}
