using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizMasterClass : MonoBehaviour {

    public Vector3 mousePos;
    public ActivityMatch selectedOne;
    public InstructionsPanel instPanel;
    public Vector2[] rightAnswers;

    static bool isRetrying = false;

    short pointCount = 0;
    bool isWin = false;
    void Start()
    {
        HelpBtn();
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        if (!isWin) confirm();
    }

    public void HelpBtn()
    {
        if (isRetrying) instPanel.ShowPopUp("هناك خطأ أعد مرة أخرى");
        else instPanel.ShowPopUp("أربط بسهم");
        isRetrying = false;

    }

    void confirm()
    {

        if (pointCount == rightAnswers.Length)
        {
            instPanel.ShowPopUp("أحسنت");
            isWin = true;
            isRetrying = false;
        }

    }

    public void Retry()
    {
        isRetrying = true;
        SceneManager.LoadScene("QuizGameMatching");
    }

    public void ReturnBtn()
    {
        SceneManager.LoadScene("MainArScene");
    }

   public void SetNewLinePos(Vector2 newPos)
    {
        selectedOne.isPressed = false;
        selectedOne.myLine.SetPosition(1, newPos);
        selectedOne.isMatchedFunction();
    }

   public void CheckTheSolution(short part1Indice,short part2Indice)
   {
       
       if (rightAnswers[part1Indice].y == part2Indice)
       {
           Debug.Log("RIGHT ANSWER");
           pointCount++;
       }

   }
	
}
