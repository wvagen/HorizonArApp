using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlanetAxe : MonoBehaviour {

    public float planetRotSpeed = 4f;
    public MainMenuManager mainMenyManager;
    public bool isPlanetAxeRelatedToRealAxe = true;

    bool infoPanelIsDisplayed = false;

	void Start () {
         planetRotSpeed = Random.Range(20, 50f);
            
	}




	void Update () {
        if (!MainMenuManager.isPreviewingPlanet && isPlanetAxeRelatedToRealAxe)
        transform.Rotate(-Vector3.up * planetRotSpeed * Time.deltaTime);

        if (MainMenuManager.isPreviewingPlanet && !isPlanetAxeRelatedToRealAxe)
            transform.Rotate(-Vector3.up * planetRotSpeed * Time.deltaTime);

        if (!isPlanetAxeRelatedToRealAxe && GetComponent<MeshRenderer>().enabled && !infoPanelIsDisplayed)
        {
            infoPanelIsDisplayed = true;
            mainMenyManager.ShowInfoPanel("أنقر على الكوكب");
        }
        
	}
}
