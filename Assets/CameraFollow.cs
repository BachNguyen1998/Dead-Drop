using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;
	// Update is called once per frame
	void Update () {
        if (target.position.y > transform.position.y) {
            Vector3 newPos = new Vector3(transform.position.x,target.position.y,transform.position.z);
            transform.position = newPos;
        }
        if(target.position.y + 4 < transform.position.y) {
            Vector3 newPos = new Vector3(transform.position.x, target.position.y+4, transform.position.z);
            transform.position = newPos;
        }
    }
}
