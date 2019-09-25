using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPDrop : MonoBehaviour
{
    private GameObject player;
    public float cooldownToMove;
    public float movespeed;
    private float movetime;
    public float expValue;
    public Playstat playersExp;
    
    private void Start()
    {
        movetime = Time.time + cooldownToMove;
        player = GameObject.Find("Hero");
    }

    private void Update()
    {
        dropBehavior();
    }

    void dropBehavior()
    {
        if(Time.time >= movetime)
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 0f;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movespeed * Time.deltaTime);
        }
        if(Vector3.Distance(transform.position, player.transform.position) < 0.1 && Time.time >= movetime)
        {
            playersExp.value += expValue;
            Destroy(gameObject);
        }
    }
}
