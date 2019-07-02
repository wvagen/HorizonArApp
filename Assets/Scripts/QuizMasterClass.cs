using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizMasterClass : MonoBehaviour {

    public Vector3 mousePos;
    public ActivityMatch selectedOne;
    public InstructionsPanel instPanel;
    public Vector2[] rightAnswers;

    short pointCount = 0;

    void Start()
    {
        HelpBtn();
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
    }

    public void HelpBtn()
    {
        instPanel.ShowPopUp();
    }

    public void confirmBtn()
    {
        if (pointCount == rightAnswers.Length)
            instPanel.ShowPopUp("أحسنت");
        else instPanel.ShowPopUp("ركز");

    }

    public void ReturnBtn()
    {
        SceneManager.LoadScene("MainMenu");
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
