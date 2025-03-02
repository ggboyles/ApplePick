using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    // prefab for instantiating apples
    public GameObject applePrefab;

    [Header("Branch Settings")]
    public GameObject branchPrefab;
    public float branchSpawnChance = 0.1f; // 10% branch spawn chance

    // speed at which the AppleTree moves
    public float speed = 1f;

    // distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // chance that AppleTree will change directions
    public float changeDirChance = 0.1f;

    // seconds between Apples instantiations
    public float appleDropDelay = 1f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // start dropping apples
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject objToSpawn;

        if (Random.value < branchSpawnChance)
        {
            objToSpawn = Instantiate<GameObject>(branchPrefab);
        }
        else
        {
            objToSpawn = Instantiate<GameObject>(applePrefab);
        }

        objToSpawn.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }


    // Update is called once per frame
    void Update()
    {
        // basic movement 
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // changing directions
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // move right 
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // move left
        }
    }

    void FixedUpdate()
    {
        // random direction changes now are time based due to FixedUpdate()
        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }
}
