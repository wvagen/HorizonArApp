using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UPersian.Components;

public class InstructionsPanel : MonoBehaviour {

    Animator myAnim;
    public RtlText myRtlTxt;

	void Start () {
        myAnim = GetComponent<Animator>();
	}

    public void ShowPopUp()
    {
        myAnim.Play("PopUpShow");
    }
    public void ShowPopUp(string instructionTxt)
    {
        myRtlTxt.text = instructionTxt;
        myAnim.Play("PopUpShow");
    }
    public void ShowUpDown()
    {
        myAnim.Play("PopUpHide");
    }


}
