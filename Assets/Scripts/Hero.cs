using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    public List<GameObject> allTargets = new List<GameObject>();
    public Enemy target;
    private Transform EnemyHolder;

    public float speed;
    public float attackRange;
    public bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        EnemyHolder = GameObject.Find("Enemies").transform;
        target = null;
        populateTargetList();
        findNearestTarget(); 
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!hasTarget())
        {
            populateTargetList();
            findNearestTarget();
        }
         
       if(hasTarget() && canMove && !inRange())
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
       else if (hasTarget() && inRange())
        {
           attack();
        }
    }

    private void attack()
    {
        print("Attacking -- "+target);
        allTargets.Remove(target.gameObject);
        Destroy(target.gameObject);
        target = null;
        
    }

    public bool hasTarget()
    {
   
        if (target != null)
        {
            print("target is " + target);
            return true;
        }
        else
        {
            print("No Targets");
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
        float closest = 100000f;
        Enemy tempTarget = null;
        foreach (GameObject e in allTargets)
        {
                float distance = Vector3.Distance(transform.position, e.transform.position);
                if (distance < closest)
                {
                    tempTarget = e.GetComponent<Enemy>();
                    closest = distance;
                }
            
        }
        print("Target Selected -- " + tempTarget);
        target = tempTarget.GetComponent<Enemy>();
    }
 
    void populateTargetList()
    {
        
        allTargets.Clear();
        foreach (Transform e in EnemyHolder)
        {
            allTargets.Add(e.gameObject);
        }
        print("Found "+allTargets.Count+" targets");
    }
}
