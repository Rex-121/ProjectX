using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl
{

    // 获得横向
    public static float Horizontal()
    {
        return Input.GetAxisRaw("Horizontal");
    }


    // 获得纵向
    public static float Vertical()
    {
        return Input.GetAxis("Vertical");
    }

}
