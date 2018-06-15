using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    public GameObject wallPrefab;
    public int numberOfWalls = 200;
    public float wallHeight = 12.16f;
    public float wallPosXRight = 3.21f;
    public float wallPosXLeft = -3.21f;
    // Use this for initialization
    void Start()
    {
        Vector3 spawnPositionRight = new Vector3();
        Vector3 spawnPositionLeft = new Vector3();
        Quaternion angle = new Quaternion(0, 0, 180, 0);

        for (int i = 0; i < numberOfWalls; i++)
        {
            spawnPositionRight.y += wallHeight;
            spawnPositionRight.x = wallPosXRight;
            spawnPositionLeft.y += wallHeight;
            spawnPositionLeft.x = wallPosXLeft;
            Instantiate(wallPrefab, spawnPositionRight, Quaternion.identity);
            Instantiate(wallPrefab, spawnPositionLeft, angle);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
