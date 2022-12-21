using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineProjectile : MonoBehaviour {
     
    public float speed = 5.0f;
 
    public float magnitude = 0.5f;   // Size of sine movement
    private Vector3 axis;
 
    private Vector3 pos;
 
    
    [SerializeField] int dotsNumber;
    [SerializeField] GameObject dotPrefab;
    [SerializeField] float dotSpacing;
    [SerializeField] float frequency;
    [SerializeField] float lifetime;
    [SerializeField] [Range (0.01f, 0.3f)] float dotMinScale;
    [SerializeField] [Range (0.3f, 1f)] float dotMaxScale;

    GameObject[] dotsList;

    //dot pos
    float timeStamp;
    
    void Start () {
        pos = transform.position;
        Object.Destroy(gameObject, lifetime);
        axis = transform.up;
        PrepareDots();
    }
     
    void Update ()
    {
        pos += transform.right * speed * Time.deltaTime;
        transform.position = pos + axis * Mathf.Sin(frequency * pos.x) * magnitude;
        ProgressiveHideDots();
    }
    
    void PrepareDots ()
    {
        dotsList = new GameObject[dotsNumber];

        float scale = dotMaxScale;
        float scaleFactor = scale / dotsNumber;

        for (int i = 0; i < dotsNumber; i++) {
            dotsList[i] = Instantiate (dotPrefab, null);
            dotsList[i].transform.localScale = new Vector3(2, 2);
            // if (scale > dotMinScale)
            //     scale -= scaleFactor;
        }
        
        UpdateDots();
    }

    public void UpdateDots ()
    {
        timeStamp = dotSpacing;
        Vector3 position = new Vector3();
        position = transform.position;
        for (int i = 0; i < dotsNumber; i++)
        {
            position.y = transform.position.y;
            
            position += transform.right * speed * dotSpacing;
            position += axis * Mathf.Sin (position.x * frequency) * magnitude;
            dotsList[i].transform.position = position;
        }
    }

    public void ProgressiveHideDots()
    {
        for (int i = 0; i < dotsNumber; i++)
        {
            if (dotsList[i].transform.position.x < transform.position.x)
            {
                dotsList[i].SetActive(false);
            }
        }
    }

    public void OnDestroy()
    {
        for (int i = 0; i < dotsNumber; i++)
        {
            Object.Destroy(dotsList[i]);
        }
    }
}