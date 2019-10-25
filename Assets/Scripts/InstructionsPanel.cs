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
        
    }



    IEnumerator PlayAfterEndOfFrame()
    {
        yield return new WaitForEndOfFrame();
        myAnim.Play("InstructionPanelOpen");
    }
    public void ShowPopUp(string instructionTxt)
    {
        myRtlTxt.text = instructionTxt;
        StartCoroutine(PlayAfterEndOfFrame());
    }
    public void ShowUpDown()
    {
        myAnim.Play("InstructionPanelClose");
    }


}
