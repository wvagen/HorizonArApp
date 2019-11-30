using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ScreenshotPreview : MonoBehaviour {

    public GameObject photoPrefab,arrows,noPhotosGO;
    public Transform albumTransform;

	[SerializeField]
	GameObject canvas;
	string[] files = null;
	int whichScreenShotIsShown= 0;

    bool isPhotoDisplayed = false;

	// Use this for initialization
	void Start () {
        
        
		files = Directory.GetFiles(Application.persistentDataPath + "/", "*.png"); //for android
        //files = Directory.GetFiles("C:/Users/Mouadh Mkadmi/Documents/Unity Projects/HorizonArApp" + "/", "*.png"); // for pc
		if (files.Length > 0) {
            Debug.Log(files.Length);
            GenerateAlbumPhotos();
            noPhotosGO.SetActive(false);
        }
        else
        {
            noPhotosGO.SetActive(true);
        }
	}


    void GenerateAlbumPhotos()
    {
        for (int i = 0; i < files.Length; i++)
        {
            GameObject tempPhoto = Instantiate(photoPrefab, Vector2.zero, Quaternion.identity, albumTransform);
            GetPictureAndShowIt(tempPhoto, i);
            tempPhoto.GetComponent<Button>().onClick.AddListener(DisplayPhoto);
        }
    }

    void DisplayPhoto()
    {
        canvas.GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite ;
        canvas.GetComponent<Image>().enabled = true;
        arrows.SetActive(true);
        albumTransform.gameObject.SetActive(false);
        isPhotoDisplayed = true;

    }

	void GetPictureAndShowIt(GameObject canvasToDraw,int count)
	{
        string pathToFile = files[count];
		Texture2D texture = GetScreenshotImage (pathToFile);
		Sprite sp = Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height),
			new Vector2 (0.5f, 0.5f));
        canvasToDraw.GetComponent<Image>().sprite = sp;
	}

    public void ReturnBtn()
    {
        if (isPhotoDisplayed)
        {
            canvas.GetComponent<Image>().enabled = false;
            arrows.SetActive(false);
            albumTransform.gameObject.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

	Texture2D GetScreenshotImage(string filePath)
	{
		Texture2D texture = null;
		byte[] fileBytes;
		if (File.Exists (filePath)) {
			fileBytes = File.ReadAllBytes (filePath);
			texture = new Texture2D (2, 2, TextureFormat.RGB24, false);
			texture.LoadImage (fileBytes);
		}
		return texture;
	}

	public void NextPicture()
	{
		if (files.Length > 0) {
			whichScreenShotIsShown += 1;
			if (whichScreenShotIsShown > files.Length - 1)
				whichScreenShotIsShown = 0;
			GetPictureAndShowIt (canvas,whichScreenShotIsShown);
		}
	}

	public void PreviousPicture()
	{
		if (files.Length > 0) {
			whichScreenShotIsShown -= 1;
			if (whichScreenShotIsShown < 0)
				whichScreenShotIsShown = files.Length - 1;
            GetPictureAndShowIt(canvas, whichScreenShotIsShown);
		}
	}
}
