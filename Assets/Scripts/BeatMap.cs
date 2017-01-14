using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMap : MonoBehaviour {
    public float time;
    public GameObject button1;
    public GameObject[] buttons;
    //public int no_of_beats = 0;                                // total no of beats

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        int timer = (int)Mathf.Ceil(time);                  // ensure time is in seconds and not milliseconds
        int no_of_beats = 0;
        //------------beat spawner--------------//
        int distance = 0;                                     // distance bw player and buttons
        float x = Random.Range(-10, 10);
        float y = Random.Range(1, 10);
        float z = Random.Range(-10, 10);
        float insideroot = 0;           // needed to find distance between player and buttons
        Vector3 position = new Vector3(x, y, z);            // temp position of button
        if (timer == 1)                 // ensure only 1 beat at a time
        {
            Vector3 radius = new Vector3(30, 30, 30);
            int tries = 0;
            while ((distance != 10 || !CheckBounds(position, radius, 1 << 7)) && ++tries < 50) 
            {
                x = Random.Range(-10, 10);
                y = Random.Range(1, 10);
                z = Random.Range(-10, 10);
                insideroot = x * x + y * y + z * z;
                distance = (int)Mathf.Sqrt(insideroot);
                position = new Vector3(x, y, z);
            }
            Instantiate(button1, position, Quaternion.identity);
            no_of_beats += 1;
        }
    }

    public static bool CheckBounds(Vector3 position, Vector3 boundsSize, int layerMask)
    {
        Bounds boxBounds = new Bounds(position, boundsSize);

        float sqrHalfBoxSize = boxBounds.extents.sqrMagnitude;
        float overlapingSphereRadius = Mathf.Sqrt(sqrHalfBoxSize + sqrHalfBoxSize);

        /* Hoping I have the previous calculation right, move on to finding the nearby colliders */
        Collider[] hitColliders = Physics.OverlapSphere(position, overlapingSphereRadius, layerMask);
        foreach (Collider otherCollider in hitColliders)
        {
            //now we ask each of thoose gentle colliders if they sens something is within their bounds
            if (otherCollider.bounds.Intersects(boxBounds))
                return (false);
        }
        return (true);
    }

    void beatSpawner(int time, int count) // time: seconds since song start, count: how many beats/counts in that second
    {
        /*
        int distance = 0;                                     // distance bw player and buttons
        float x = 0, y = 0, z = 0, insideroot = 0;           // needed to find distance between player and buttons
        Vector3 position = new Vector3(x, y, z);            // temp position of button
        if (time == 1 && no_of_beats < 1)                 // ensure only 1 beat at a time
        {
            while (distance != 10) //&& Physics.CheckSphere(position, 4))
            {
                x = Random.Range(-10, 10);
                y = Random.Range(3, 10);
                z = Random.Range(-10, 10);
                insideroot = x * x + y * y + z * z;
                distance = (int)Mathf.Sqrt(insideroot);
                position = new Vector3(x, y, z);
            }
            Instantiate(button1, position, Quaternion.identity);
            no_of_beats += 1;
        }*/
    }
}
