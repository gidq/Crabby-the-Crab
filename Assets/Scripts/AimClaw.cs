using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEditor.Build;

public class AimClaw : MonoBehaviour
{
    public  Transform aim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = UtilsClass.GetMouseWorldPosition();
        
        Vector3 aimDirection = (mousePos - transform.position).normalized;

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        
        aim.eulerAngles = new Vector3(0,0,angle);

        Vector3 Lscale = Vector3.one;
        Vector3 aimScale = Vector3.one;

        

        if (angle > 117 || angle < -100)
        {
            
            Lscale.x = -1f;
            aimScale.x = -1f;
            aimScale.y = -1f;
        }
        else
        {
            Lscale.x = 1f;
        }

        transform.localScale = Lscale;
        aim.localScale = aimScale;
        
    }
}
