using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cannonBall;
    public float initialDelay = 3.0f;
    public float intervalDelay = 5.0f;
    
    void Start()
    {
        InvokeRepeating("ShootCannonBall", initialDelay, intervalDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShootCannonBall()
    {
        var newCannonBall = Instantiate(cannonBall, cannonBall.transform.position, cannonBall.transform.rotation);
        newCannonBall.SetActive(true);
    }
}
