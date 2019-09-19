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
        GameObject c = GameObject.Find("Center");
        if (Vector3.Distance(transform.position, h.transform.position) >= 1)
        {
            Vector3 moveTarget = new Vector3(h.transform.position.x - 1, c.transform.position.y, 0);
            transform.position = Vector3.MoveTowards(transform.position, moveTarget, speed * Time.deltaTime);
        }
        
        
    }
}
