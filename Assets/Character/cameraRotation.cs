using UnityEngine;
using System.Collections;

public class cameraRotation : MonoBehaviour
{

    private bool isRotatingDown;
    private bool isRotatingUp; // Is the camera being rotated?

    //
    // UPDATE
    //

    void Update()
    {
        // On descend la caméra
        if (Input.GetKeyDown("b"))
        {
            isRotatingDown = true;
        }

        // On remonte la caméra
        if (Input.GetKeyDown("h"))
        {
            isRotatingUp = true;
        }


        // Rotate camera along X axis
        if (isRotatingDown)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(new Vector3(0, -280, 0));
            float x = Camera.main.transform.eulerAngles.x;
            if (x < 80)
            {
                transform.RotateAround(transform.position, transform.right, -pos.y);
            }
            else
            {
                isRotatingDown = false;
            }
        }

        //Rotate camera along X axis
        if (isRotatingUp)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(new Vector3(0, -280, 0));
            float x = Camera.main.transform.eulerAngles.x;
            if (x > 2)
            {
                transform.RotateAround(transform.position, transform.right, pos.y);
            }
            else
            {
                isRotatingUp = false;
            }
        }
    }
    
    //public void cameraUp()
    //{
    //    isRotatingUp = true;
    //}
}