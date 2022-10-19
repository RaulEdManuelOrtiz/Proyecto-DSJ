using UnityEngine;

public class MoveBird : MonoBehaviour {

    public GameObject goal;
    private Vector3 direction;
    private float speed = 8f;
    void Start()
    {
        // direction = goal.transform.position - this.transform.position;
        // this.transform.Tramslate(direction);
    }

    private void LateUpdate()
    {
        direction = goal.transform.position - this.transform.position;
       // this.transform.LookAt(goal.transform.position);
        
        if (direction.magnitude > 8)
        {
            Vector3 velocity = direction.normalized * speed * Time.deltaTime;
            this.transform.position = this.transform.position + velocity;
        }
    }
}