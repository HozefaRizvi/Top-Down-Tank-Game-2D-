using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public float followspeed = 2f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {   
        Vector3 newpositon = new Vector3(target.position.x, target.position.y,-10);
        transform.position = Vector3.Slerp(transform.position,newpositon,followspeed*Time.deltaTime);
    }
}
