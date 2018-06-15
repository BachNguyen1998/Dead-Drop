using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class BoxGenerator : MonoBehaviour {
    public GameObject boxPrefab;
    public float width = 2.151f;
    public float minHeight = 18.94f;
    public float maxHeight = 54.5f;
    public float delay = 1f;
    Vector3 spawnPosition = new Vector3();
    // Use this for initialization
    void Start () {
        InvokeRepeating("spawnBox",2.0f,delay);
	}
	
	// Update is called once per frame
	void spawnBox () {
        spawnPosition.x = Random.Range(-width,width);
        spawnPosition.y = Random.Range(minHeight,maxHeight);
        Instantiate(boxPrefab,spawnPosition,Quaternion.identity);
	}
}
