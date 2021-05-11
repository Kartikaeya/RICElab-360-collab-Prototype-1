using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 10f;
    float curr_x = 0f;
    float curr_y = 0f;
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        curr_x += x;
        curr_y -= y;
        transform.rotation = Quaternion.Euler(curr_y, curr_x, 0);
    }
}
