using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    public GameObject[] waypoints;
    int currentWP = 0;

    public float speed = 10.0f;
    public float rotSpeed = 10.0f;
    public float lookAhead = 10.0f;
    
    
    // Start is called before the first frame update
    void ProgressTracker()
    {
        if (Vector2.Distance(this.transform.position, waypoints[currentWP].transform.position) < 3)
        {
            currentWP++;
        }
        if (currentWP >= waypoints.Length)
        {
            currentWP = 0;
        }
        Vector2 directionOfTravel = waypoints[currentWP].transform.position - this.transform.position;
        directionOfTravel.Normalize();
        this.transform.Translate(
            directionOfTravel.x * speed * Time.deltaTime,
            directionOfTravel.y * speed * Time.deltaTime,
            0,
            Space.World
        );
    }

    // Update is called once per frame
    void Update()
    {
        ProgressTracker();
        this.transform.Rotate (0,0,150 * Time.deltaTime);
    }
}
