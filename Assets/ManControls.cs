using UnityEngine;
using System.Collections;

public class ManControls : MonoBehaviour {
    private Animator myAnimator;
    private float movementSpeed  = 5.0F;
    private float rotationSpeed = 100F;
    private Transform myTransform;
    private float rightLeftRotation = 0.0f;
    public float mouseSensitivity = 5.0f;
    public float upDownRange = 60.0f;
    float verticalRotation = 0;

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

        //float rotation1 = Input.GetAxis("Horizontal") * rotationSpeed;
        //myAnimator.SetFloat("VSpeed", Input.GetAxis("Vertical"));
        //rotation1 *= Time.deltaTime;
        ////transform.Rotate(0, rotation1, 0);

        float rotLeftright = Input.GetAxis("Mouse X");
        transform.Rotate(0, rotLeftright, 0);

        verticalRotation -= Input.GetAxis("Mouse Y");
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);


        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed);
        speed = transform.rotation * speed;
        CharacterController cc = GetComponent<CharacterController>();
        cc.SimpleMove(speed);



    }


}
