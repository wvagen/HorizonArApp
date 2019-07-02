using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlanetAxe : MonoBehaviour {

    public float planetRotSpeed = 4f;
    public bool isPlanetAxeRelatedToRealAxe = true;

	void Start () {
         planetRotSpeed = Random.Range(20, 50f);
	}


	void Update () {
        if (!MainMenuManager.isPreviewingPlanet && isPlanetAxeRelatedToRealAxe)
        transform.Rotate(-Vector3.up * planetRotSpeed * Time.deltaTime);

        if (MainMenuManager.isPreviewingPlanet && !isPlanetAxeRelatedToRealAxe)
            transform.Rotate(-Vector3.up * planetRotSpeed * Time.deltaTime);
	}
}
