using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	
	void Update () {
        RotateMe();
	}

    void RotateMe()
    {
        transform.Rotate(Vector3.up * 20 * Time.deltaTime);
    }
}
