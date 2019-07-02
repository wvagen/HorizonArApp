using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotPlayer : MonoBehaviour {

    Animator myAnim;
	void Start () {
        myAnim = GetComponent<Animator>();
	}

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void WaveAnimation()
    {
        myAnim.Play("Idle", -1, 0f);
    }

    public void ZigZagAnimation()
    {
        myAnim.Play("ZigZag Dance", -1, 0f);
    }

}
