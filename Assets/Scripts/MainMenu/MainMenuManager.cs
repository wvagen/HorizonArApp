using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

    public Animator myAnim;
    public Transform pointOfViewPos;
    public Text infoTxt;

    public Text loadingTxt;

    public SetInfoObject clickedPlanet;
    public static bool isPreviewingPlanet = false;

    public void LoadScene(string sceneName)
    {
        if (loadingTxt != null)
            StartCoroutine(LoadSceneCoroutine(sceneName));
        else SceneManager.LoadScene(sceneName);
    }

    IEnumerator LoadSceneCoroutine(string sceneName)
    {
        yield return null;

        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
        Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            loadingTxt.text = "Loading progress:\n " + (asyncOperation.progress * 100) + "%";

            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                    asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    public void DispalyAndHideHelpPanel(bool isShowing)
    {
        if (isShowing) myAnim.Play("ScaleHelpPanel");
        else myAnim.Play("ShrinkHelpPanel");
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
