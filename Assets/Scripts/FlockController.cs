using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockController : MonoBehaviour
{
    public float minVelocity = 5;
    public float maxVelocity = 20;
    public float randomness = 1;
    public int flockSize = 20;
    public GameObject prefab;
    public GameObject chasee;

    public float alignmentWeight = 1;
    public float cohesionWeight = 1;
    public float separationWeight = 1;

    private float initialCohesionWeight;
    private float initialSeparationWeight;
    
    public float separationDistance = 1;
    public float cohesionDistance = 10;
    
    private Vector2 averageHeading;
    private Vector2 averagePosition;
    private float flockSpeed;
    private List<GameObject> flock = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < flockSize; i++)
        {
            Vector2 position = new Vector2(
                Random.value * GetComponent<Collider2D>().bounds.size.x,
                Random.value * GetComponent<Collider2D>().bounds.size.y
            );
            GameObject flockMember = Instantiate(prefab, position, Quaternion.identity);
            flockMember.transform.parent = transform;
            flock.Add(flockMember);
        }

        initialCohesionWeight = cohesionWeight;
        initialSeparationWeight = separationWeight;
    }

    void Update()
    {
        Vector2 center = Vector2.zero;
        Vector2 velocity = Vector2.zero;
        foreach (GameObject member in flock)
        {
            center += (Vector2) member.transform.position;
            velocity += member.GetComponent<Rigidbody2D>().velocity;
        }

        averagePosition = center / flockSize;
        averageHeading = velocity / flockSize;
        flockSpeed = averageHeading.magnitude;
        if (flockSpeed == 0)
        {
            flockSpeed = 20;
        }
        if (flockSpeed > maxVelocity)
        {
            averageHeading = averageHeading * maxVelocity / flockSpeed;
        }

        if (flockSpeed < minVelocity)
        {
            averageHeading = averageHeading * minVelocity / flockSpeed;
        }

        chasee = GameObject.FindGameObjectWithTag("Player");
        if (chasee)
        {
            averagePosition = chasee.transform.position;
        }
    }

    void LateUpdate()
    {
        foreach (GameObject member in flock)
        {
            // Calculate alignment
            Vector2 alignment = averageHeading * Time.deltaTime;

            // Calculate cohesion
            Vector2 cohesion = (averagePosition - (Vector2)member.transform.position) * Time.deltaTime;

            // Calculate separation
            Vector2 separation = Vector2.zero;
            foreach (GameObject otherMember in flock)
            {
                if (otherMember != member)
                {
                    separation += ((Vector2)member.transform.position - (Vector2)otherMember.transform.position) * Time.deltaTime;
                }
            }
            separation /= flockSize - 1;
            
            float distance = Vector2.Distance(member.transform.position, averagePosition);
            if (distance > cohesionDistance)
            {
                cohesionWeight = initialCohesionWeight;
                separationWeight = 1;
            } else if (distance < separationDistance)
            {
                separationWeight = initialSeparationWeight;
                cohesionWeight = 1;
            }
            
            Debug.Log(alignment);
            Debug.Log(cohesion);
            Debug.Log(separation);
            // Calculate the overall direction
            Vector3 direction = alignment * alignmentWeight + cohesion * cohesionWeight + separation * separationWeight + Random.insideUnitCircle * randomness * Time.deltaTime;

            // Update the member's velocity
            member.GetComponent<Rigidbody2D>().velocity = direction;
        }
    }
}