using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMoving : MonoBehaviour {

    Rigidbody myRig;


	void Start () {
        myRig = GetComponent<Rigidbody>();
        myRig.velocity = transform.forward ;
	}

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space)){
           StartCoroutine(RotateRandomRotation());
            Debug.Log ("Yeah");
        }*/
        myRig.velocity = transform.forward ;
    }

    IEnumerator RotateRandomRotation(){

        float randYRot = Random.Range(0, 360);
        if (transform.eulerAngles.y > randYRot)
        {
            while (transform.eulerAngles.y > randYRot)
            {
                transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * 250, Space.World);
                yield return new WaitForEndOfFrame();
            }
        }else {
            while (transform.eulerAngles.y < randYRot)
            {
                transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * 250, Space.World);
                yield return new WaitForEndOfFrame();
            }
        }
    }

    void OnCollisionEnter(Collision myCol)
    {
        if (myCol.gameObject.tag == "Obs")
        StartCoroutine(RotateRandomRotation());
    }
    void OnCollisionStay(Collision myCol)
    {
        if (myCol.gameObject.tag == "Obs")
        {
            StartCoroutine(RotateRandomRotation());
            transform.position = transform.parent.parent.position;
        }
    } 
	
}
