using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeScreenshot : MonoBehaviour {

    public GameObject[] gameObjectsToDisableBeforeShutting;

	public void TakeAShot()
	{
		StartCoroutine ("CaptureIt");
	}

    void DisableEnableGameObjects(bool canEnable)
    {
        foreach (GameObject item in gameObjectsToDisableBeforeShutting)
        {
            item.SetActive(canEnable);
        }
    }

	IEnumerator CaptureIt()
	{
        DisableEnableGameObjects(false);
        yield return new WaitForSeconds(.5f);
		string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
		string fileName = "Screenshot" + timeStamp + ".png";
		string pathToSave = fileName;
		ScreenCapture.CaptureScreenshot(pathToSave);
        Debug.Log(fileName);
		yield return new WaitForSeconds(1);
        DisableEnableGameObjects(true);
	}

}
