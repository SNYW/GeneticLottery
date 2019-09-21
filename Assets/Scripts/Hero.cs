using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    public List<GameObject> allTargets = new List<GameObject>();
    public Enemy target;
    private Transform EnemyHolder;
    public GameObject Center;
    public float visionRange;
    public Animator animator;

    public float speed;
    public float attackRange;
    public bool canMove;

    //Code for directional movement tracking
    private Vector3 lastPos;
    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
        animator.SetFloat("Speed", 0);
        canMove = true;
        EnemyHolder = GameObject.Find("Enemies").transform;
        populateTargetList();
        findNearestTarget(); 
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
        if (target == null)
        {   
            animator.SetFloat("Speed", 0);
            //print("Null Target");
            populateTargetList();
            findNearestTarget();
        }
       
    }

    void Update()
    {

        getDirection();



        if (!hasTarget())
        {
            print("Moving to centre");
            if (Vector3.Distance(transform.position, Center.transform.position) > 0.5)
            {
                animator.SetFloat("Speed", 1);
            }
            else
            {
                animator.SetFloat("Speed", 0);
            }
            animator.SetBool("attacking", false);
            Vector3 moveTarget = new Vector3(Center.transform.position.x, transform.position.y, 0);
            transform.position = Vector3.MoveTowards(transform.position, moveTarget, speed * Time.deltaTime);

        }
        else if (hasTarget() && canMove && !inRange())
        {
            animator.SetBool("attacking", false); 
            animator.SetFloat("Speed", 1);
            Vector3 moveTarget = new Vector3(target.transform.position.x, transform.position.y, 0);
            transform.position = Vector3.MoveTowards(transform.position, moveTarget, speed * Time.deltaTime);
            
        }
        else if (hasTarget() && inRange())
        {
           attack();
           animator.SetBool("attacking", true);
            
        }
    }

    private void getDirection()
    {
        velocity = transform.position - lastPos;
        lastPos = transform.position;

        if(velocity.x < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }

    }

    private void attack()
    {
        if(target.transform.position.x < transform.position.x)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        //print("Attacking -- "+target);
        Destroy(target.gameObject, 0.2f);
    }

    
    public bool hasTarget()
    {
   
        if (target != null)
        {
           //print("target is " + target);
            return true;
        }
        else
        {
           //print("No Targets");
            return false;
        }
        
    }

    public bool inRange()
    {
        if (hasTarget())
        {
            return Vector3.Distance(transform.position, target.gameObject.transform.position) <= attackRange;
            
        }
        else
        {
            return false;
        }
    }

    void findNearestTarget()
    {
        float closest = visionRange;
        Enemy tempTarget = null;
        foreach (GameObject e in allTargets)
        {
            float distance = Vector3.Distance(Center.transform.position, e.transform.position);
            //print(e + " ==== " + distance);
            if (distance < closest)
            {
                
                    tempTarget = e.GetComponent<Enemy>();
                    closest = distance;
                
            }
            
        }
        //print("Target Selected -- " +tempTarget+" at "+closest );
        target = tempTarget;
    }
 
    void populateTargetList()
    {
        
        allTargets.Clear();
        foreach (Transform e in EnemyHolder)
        {
            allTargets.Add(e.gameObject);
        }
        //print("Found "+allTargets.Count+" targets");
    }
}
