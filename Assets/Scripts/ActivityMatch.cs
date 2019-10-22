using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityMatch : MonoBehaviour {

    public GameObject pointToDrag;
    public QuizMasterClass masterClass;
    public LineRenderer myLine;
    public bool isPressed = false;
   
   bool isMatched = false;


    GameObject tempPoint;

    void Start()
    {
        myLine = GetComponent<LineRenderer>();
        ResetLinePositions();
    }

    void Update()
    {
        if (isPressed)
        {
            tempPoint.transform.position = masterClass.mousePos;
            myLine.SetPosition(1, masterClass.mousePos);
        }

        if (Input.GetKeyDown(KeyCode.Q)) Debug.Break();

    }

    public void OnPointerDown () {
        if (isMatched) return;
        Vector3 myPos = transform.position;
        myPos.z = 0;
        tempPoint = Instantiate(pointToDrag, myPos, Quaternion.identity);
        myLine.SetPosition(0, myPos);
        masterClass.selectedOne = this;
        isPressed = true;
	}
    public void OnPointerUp()
    {
        if (!isMatched)
            ResetLinePositions();
        masterClass.selectedOne = null;
        isPressed = false;
        Destroy(tempPoint);
    }

    void ResetLinePositions()
    {
        Vector3 myPos = transform.position;
        myPos.z = 0;
        myLine.SetPosition(0, myPos);
        myLine.SetPosition(1, myPos);
    }

    public void isMatchedFunction()
    {
        Destroy(tempPoint);
        isMatched = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Point" && masterClass.selectedOne != null
            && masterClass.selectedOne != this && 
            this.tag != masterClass.selectedOne.tag && !isMatched)
        {
            Debug.Log("YES");
            isMatched = true;
            masterClass.SetNewLinePos(transform.position);
            CheckTheSolution();
        }
    }

    void CheckTheSolution()
    {
        short myIndice = (short)int.Parse(this.gameObject.name);
        short clickedIndice = (short)int.Parse(masterClass.selectedOne.gameObject.name);
        if (this.tag == "Part1") masterClass.CheckTheSolution(myIndice, clickedIndice);
        else masterClass.CheckTheSolution(clickedIndice, myIndice);
    }

}
