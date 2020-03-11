using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManagerPortrait : MonoBehaviour
{
    public Animator myAnim;
    public GameObject generalGO;
    public GameObject selectSceneBtn;
    public GameObject selectMagazineBtn;
    public GameObject backFromSelectingMagazineBtn;

    short menuSelectedIndex = 0;

    Vector2 lastPointTouchedPos;

    string animationParameter = "menuSelected";
    bool isPressed = false;
    short limitScrollingIndex = 7;
    const float minimumDistanceForScreenScroll = 0.1f;


    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    void Update()
    {
        ScrollLogic();

    }

    void ScrollLogic()
    {
        if (Input.GetMouseButtonDown(0) && !isPressed)
        {

            lastPointTouchedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isPressed = true;
        }
        if (isPressed && Input.GetMouseButtonUp(0))
        {
            isPressed = false;

            if (Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), lastPointTouchedPos) > minimumDistanceForScreenScroll)
            {
                if (lastPointTouchedPos.x > Camera.main.ScreenToWorldPoint(Input.mousePosition).x) leftBtn();
                else rightBtn();
            }
        }
    }

    public void selectMagazine()
    {
        generalGO.SetActive(true);
        selectMagazineBtn.SetActive(true);
        selectSceneBtn.SetActive(false);
        backFromSelectingMagazineBtn.SetActive(true);
        animationParameter = "newMenuSelected";
        limitScrollingIndex = 1;

    }

    public void backFromSelectingMagazine()
    {
        generalGO.SetActive(false);
        selectMagazineBtn.SetActive(false);
        selectSceneBtn.SetActive(true);
        backFromSelectingMagazineBtn.SetActive(false);
        animationParameter = "menuSelected";
        limitScrollingIndex = 7;
    }


    public void loadScene()
    {
        if (menuSelectedIndex == 0)
        {
            selectMagazine();

        }
        if (menuSelectedIndex == 4)
        {
            SceneManager.LoadScene("Gallery");
        }
        //else
        //{
        //    try
        //    {
        //        SceneManager.LoadScene(menuSelectedIndex + 1);
        //    }
        //    catch (UnassignedReferenceException err)
        //    {
        //        Debug.Log(err.Message);
        //    }
        //}
    }

    public void loadMagazineAr()
    {
        if (menuSelectedIndex == 0)
        {
            SceneManager.LoadScene("MainArScene");
        }
    }

    public void rightBtn()
    {
        if (menuSelectedIndex < limitScrollingIndex)
            menuSelectedIndex++;
        else menuSelectedIndex = 0;
        myAnim.SetInteger(animationParameter, menuSelectedIndex);
    }
    public void leftBtn()
    {
        if (menuSelectedIndex > 0)
            menuSelectedIndex--;
        else menuSelectedIndex = limitScrollingIndex;
        myAnim.SetInteger(animationParameter, menuSelectedIndex);
    }

}
