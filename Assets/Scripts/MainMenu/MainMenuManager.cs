using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

    public Animator myAnim;
    public Transform pointOfViewPos;
    public Text infoTxt;

    public SetInfoObject clickedPlanet;
    public static bool isPreviewingPlanet = false;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ShowInfoPanel(string info)
    {
        infoTxt.text = info;
        myAnim.Play("InformationPanelInfo");
    }

    public void CloseInfoPanel()
    {
        myAnim.Play("InfoPanelClose");
        if (clickedPlanet != null) clickedPlanet.ReturnToViewPoint();
    }

}
