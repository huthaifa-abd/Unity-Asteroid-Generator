using UnityEngine;
using System.Collections;

public class CollisionRaycastScript : MonoBehaviour
{

    public bool bUpward = false;
    public bool bDownward = false;
    public bool bForward = false;
    public bool bBackward = false;
    public float fDistance = 1;
    public bool _inside = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] raycastDirections = new Vector3[5];
        raycastDirections[0] = new Vector3(0, 1, 0);
        raycastDirections[1] = new Vector3(0, -1, -0);
        raycastDirections[2] = new Vector3(0, 0, 1);
        raycastDirections[3] = new Vector3(-1.41f, 0, -0.5f);
        raycastDirections[4] = new Vector3(1.41f, 0, -0.5f);
        int hitcount = 0;

        foreach (Vector3 direction in raycastDirections) {
            Debug.DrawRay(transform.position - fDistance * direction, direction * fDistance, Color.green);
            if (Physics.Raycast(transform.position - fDistance * direction, direction * fDistance))
            {
                hitcount++;
            }
        }

        if (hitcount >= 5)
            _inside = true;
        else
            _inside = false;

        //RaycastHit hit;
        //Vector3 forward = transform.TransformDirection(Vector3.forward);
        //Debug.DrawRay(transform.position - fDistance * forward, forward * fDistance, Color.green);
        //if (Physics.Raycast(transform.position - fDistance * forward, forward * fDistance, out hit, fDistance))
        //    if (hit.transform.name == "Gizmo")
        //    {
        //        bForward = true;
        //    }


        //Vector3 backward = transform.TransformDirection(Vector3.back);
        //Debug.DrawRay(transform.position - fDistance * backward, fDistance * backward, Color.red);
        //if (Physics.Raycast(transform.position - fDistance * backward, fDistance * backward, out hit, fDistance))
        //    if (hit.transform.name == "Gizmo")
        //    {
        //        bBackward = true;
        //    }


        //Vector3 upward = transform.TransformDirection(Vector3.up);
        //Debug.DrawRay(transform.position - fDistance * upward, fDistance * upward, Color.yellow);
        //if (Physics.Raycast(transform.position - fDistance * upward, fDistance * upward, out hit, fDistance))
        //    if (hit.transform.name == "Gizmo")
        //    {
        //        bUpward = true;
        //    }



        //Vector3 downward = transform.TransformDirection(Vector3.down);
        //Debug.DrawRay(transform.position - fDistance * downward, fDistance * downward, Color.white);
        //if (Physics.Raycast(transform.position - fDistance * downward, fDistance * downward, out hit, fDistance))
        //    if (hit.transform.name == "Gizmo")
        //    {
        //        bDownward = true;
        //    }

        
    }
}
