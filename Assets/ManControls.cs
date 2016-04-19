using UnityEngine;
using System.Collections;

public class ManControls : MonoBehaviour {
    private Animator myAnimator;
    private float movementSpeed  = 5.0F;
    private float rotationSpeed = 100F;
    private Transform myTransform;

	// Use this for initialization
	void Start () {
        myTransform = this.transform;
        myAnimator = GetComponent<Animator>();
       

    }
	
	// Update is called once per frame
	void Update () {

        // On place le manequin en position debout avant bras avant
        if (Input.GetKeyDown("b"))
        {
            myAnimator.SetTrigger("isCarrying");
        }

        // On remet le manequin en position nomrale
        if (Input.GetKeyDown("h"))
        {
            myAnimator.ResetTrigger("isCarrying");
        }

        if (Input.GetKeyDown("s"))
        {
            if (myAnimator.GetBool("isSit"))
                myAnimator.ResetTrigger("isSit");
            else
                myAnimator.SetTrigger("isSit");
        }

        if (Input.GetKeyDown("t"))
        {
            if (myAnimator.GetBool("isDancing"))
                myAnimator.ResetTrigger("isDancing");
            else
                myAnimator.SetTrigger("isDancing");
        }

        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        myAnimator.SetFloat("VSpeed", Input.GetAxis("Vertical"));
        rotation *= Time.deltaTime;
        transform.Rotate(0, rotation, 0);
        


    }
    

}
