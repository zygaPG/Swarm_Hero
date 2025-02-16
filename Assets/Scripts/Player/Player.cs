using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float cameraSens = 2.4f;

    [SerializeField] Transform head;

    float xCamera = 0;
    float yCamera = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        xCamera += cameraSens * Input.GetAxis("Mouse X");
        yCamera -= cameraSens * Input.GetAxis("Mouse Y");

        yCamera = Mathf.Clamp(yCamera, -90, 90);


        transform.eulerAngles = new Vector3(0, xCamera, 0);
        head.localEulerAngles = new Vector3(yCamera, 0, 0);


       // head.eulerAngles = new Vector3(yCamera, xCamera, 0);
    }
}
