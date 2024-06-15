using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GrabOBJ : MonoBehaviour
{

    public LayerMask grabbable;
    GameObject grabbedObj;
    public Animator animator;
    public float radius = 1f;
    public Transform grabObjPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Isnapping", true);

            //Vector3 mousepos = UtilsClass.GetMouseWorldPosition();

            Collider2D collider = Physics2D.OverlapCircle(grabObjPos.transform.position, radius, grabbable);

            

            if (collider != null)
            {
                grabbedObj = collider.gameObject;
                grabbedObj.transform.position = grabObjPos.position;
                grabbedObj.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObj.transform.SetParent(grabObjPos);
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            animator.SetBool("Isnapping", false);

            if (grabbedObj != null)
            {
                grabbedObj.transform.SetParent(null); // Release the object
                grabbedObj.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObj = null;
            }
        }

        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(grabObjPos.position, radius);
    }
}
