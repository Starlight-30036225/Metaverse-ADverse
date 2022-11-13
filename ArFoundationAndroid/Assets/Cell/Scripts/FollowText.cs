using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;


public class FollowText : MonoBehaviour
{
    public GameObject FollowPoint;
    public float Speed = 0.9f;
    //public TMPro.TextMeshPro Textbox;

    public float Reactivity;
    private float difference;
    private bool Moving = false;
    private Quaternion Targetrotation;
    private float Completeion;

    private Coroutine LookCoroutine;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        difference = (Mathf.Abs((float)(FollowPoint.transform.rotation.eulerAngles.y - transform.rotation.eulerAngles.y)));  //Calculates the difference in Y rotations then sets it to the difference
        difference += (Mathf.Abs((float)(FollowPoint.transform.rotation.eulerAngles.x - transform.rotation.eulerAngles.x))); //Calculates the difference in x rotations then adds it to the difference
        //difference += (Mathf.Abs((float)(FollowPoint.transform.rotation.eulerAngles.z - transform.rotation.eulerAngles.z))); //Calculates the difference in z rotations then adds it to the difference
        if (difference > Reactivity && !Moving) {

            SetNewTarget();  //If the difference is above the reactivity threshold, calls function to move to view 
        }
       

       
    }

    private void FixedUpdate()
    {
        if (Moving)
        {
            Completeion += 0.02f;
            transform.rotation = Quaternion.Slerp(transform.rotation, Targetrotation, Completeion);   //Makes object move gradually instead of suddenly
        }                                                                                       
        if (Completeion >= 1f)
        {
            Moving = false;
            Completeion = 0f;
        }

       
    }

    private IEnumerator Lookat() {
        Moving = true;
        float time = 0f;
        Targetrotation = FollowPoint.transform.rotation;  //Gets location to move to
        Targetrotation.z = 0f;  //Stops the object rotating to fit the cameras Z rotation
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Targetrotation, time);   //Makes object move gradually instead of suddenly
            //print(transform.rotation);
            time += Time.deltaTime *  Speed;

        }
        Moving = false;
        yield return null;
    }

    private void SetNewTarget() {
        Moving = true;
        //float time = 0f;
        Targetrotation = FollowPoint.transform.rotation;  //Gets location to move to
        Targetrotation.z = 0f;  //Stops the object rotating to fit the cameras Z rotation
        Completeion = 0f;
    }
}
