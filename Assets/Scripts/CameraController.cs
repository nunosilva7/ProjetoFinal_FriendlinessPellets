using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* 
    This code is based on:
        Bracekys (https://www.youtube.com/watch?v=_QajrabyTJc&t=1208s) FPS Controller
            
*/

public class CameraController : MonoBehaviour
{
    float sensivity = 80f;

    [SerializeField]
    Transform player;

    float rotationX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;


        rotationX -= mouseY;

        //limitar movimento da camera para ser mais natural
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);


    }
}
