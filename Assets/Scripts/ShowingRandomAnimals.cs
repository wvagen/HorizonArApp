using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowingRandomAnimals : MonoBehaviour {


    public Transform animalsTransform;
	List<GameObject> animalsChilds = new List<GameObject>();

    const short animalsCountToBeShowen = 5;
    void Start()
    {
        fillAnimalsList();
    }

    void fillAnimalsList()
    {
        for (int i = 0; i < animalsTransform.childCount; i++)
        {
            animalsChilds.Add(animalsTransform.GetChild(i).gameObject); 
        }
        ShowRandomAnimals();    
    }

    public void ShowRandomAnimals()
    {
        short randIndice ;
        foreach (GameObject item in animalsChilds)
        {
            item.SetActive(false);
        }
        for (int i = 0; i < animalsCountToBeShowen; i++)
        {
            do
            {
                randIndice = (short)Random.Range(0, animalsTransform.childCount);
            }
            while (animalsChilds[randIndice].activeSelf);
            animalsChilds[randIndice].SetActive(true);
        }
    }

}
