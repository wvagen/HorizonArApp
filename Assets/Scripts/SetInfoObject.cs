using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInfoObject : MonoBehaviour {

    public MainMenuManager mainMenMan;
    public string info;
    public bool canGo = false;

    Vector3 myInitPos;
    TrailRenderer myTrail;

    short myTrailInitDuration = 20;

    void Start()
    {
        myInitPos = transform.position;
        if (GetComponent<TrailRenderer>() != null)
        {
            myTrail = GetComponent<TrailRenderer>();
            myTrailInitDuration = (short)myTrail.time;
        }
    }

    void OnMouseDown()
    {
        mainMenMan.ShowInfoPanel(info);
        /*myInitPos = transform.position;
        EnableParentPlanetAxeScript(false);
        canGo = true;
        mainMenMan.clickedPlanet = this;
        MainMenuManager.isPreviewingPlanet = true;
        if (GetComponent<TrailRenderer>() != null)
        myTrail.time = 0;
        StartCoroutine(GoToViewPointAhead());*/
        
    }

    public void ReturnToViewPoint()
    {
        canGo = false;
        StartCoroutine(ReturnHome());
    }

    IEnumerator GoToViewPointAhead()
    {
        while (canGo)
        {
            transform.position = Vector3.Lerp(transform.position, mainMenMan.pointOfViewPos.position, 4 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator ReturnHome()
    {
        while (!canGo)
        {
            transform.position = Vector3.Lerp(transform.position, myInitPos, 4 * Time.deltaTime);

            if (Vector3.Distance(transform.position,myInitPos) <= 0.1f)
            {
                transform.position = myInitPos;
            canGo = true;
            if (GetComponent<TrailRenderer>() != null)
            myTrail.time = myTrailInitDuration;
            MainMenuManager.isPreviewingPlanet = false;
            EnableParentPlanetAxeScript(true);
        }
            yield return new WaitForEndOfFrame();
        }
    }

    void EnableParentPlanetAxeScript(bool isActive)
    {
        if (transform.parent.GetComponentInParent<PlanetAxe>() != null)
            transform.parent.GetComponentInParent<PlanetAxe>().enabled = isActive;
    }

}
