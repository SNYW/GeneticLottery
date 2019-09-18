using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject h = GameObject.Find("Hero");
        transform.position = Vector3.MoveTowards(transform.position, h.transform.position, speed * Time.deltaTime);
    }
}
