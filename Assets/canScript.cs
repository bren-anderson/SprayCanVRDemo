using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canScript : MonoBehaviour
{
    //when the ray hits an object, it does whatever is listed
    //protected is similar to private
    protected GameObject hitObject;
    protected RaycastHit rayHit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            Debug.Log("spray");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.yellow);
            //transform.position puts raycast to the camera, Vector.3 is the direction, out rayHit is where it comes out from, 10.0f is a float
            //origin, direction, where it comes from, float
            //statement is what it does when it collides with an object
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out rayHit, 10.0f))
            {
                //Single = assignment, double == evaluation
                if (hitObject == null)
                {
                    RayExit();
                    //hitObject creates a reference to the game object
                    hitObject = rayHit.transform.gameObject;
                    //RayEnter is called, RayHit is entered
                    RayEnter(rayHit);
                }
            }
            else
            {
                RayExit();
            }
        }
    }
    void RayExit()
    {

    }
    void RayEnter(RaycastHit hit)
    {
        //interactibleObject objScript = hit.transform.gameObject.GetComponent<interactibleObject>();
        //StartCoroutine(ObjectAction(objScript));
        Debug.Log("hit");
    }
    /*IEnumerator ObjectAction(interactibleObject obj)
    {
        yield return new WaitForSeconds(1);

        if (obj.isHidden)
        {
            Destroy(obj.gameObject);

        }
    }*/
}
