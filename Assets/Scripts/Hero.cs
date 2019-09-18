using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    public List<Enemy> allTargets = new List<Enemy>();
    public Enemy target;

    public float speed;
    public float attackRange;
    public bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        
    }

    // Update is called once per frame
    void Update()
    {
       if(hasTarget() && inRange())
        {
            attack();
        }


       if(hasTarget() && canMove && !inRange())
        {
            
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    private void attack()
    {
        print("HIYAAA");
        allTargets.Remove(target);
        Destroy(target, 2f);
        
    }

    public bool hasTarget()
    {
        return allTargets.Count > 0;
    }

    public bool inRange()
    {
        if (hasTarget())
        {
            return Vector3.Distance(transform.position, allTargets[0].transform.position) < attackRange;
            
        }
        else
        {
            return false;
        }
    }

    void findTarget()
    {
        allTargets.Clear();
        
        target = null;
        float closest = 100000f;
        Enemy tempTarget = null;
        foreach (Enemy e in allTargets)
        {
            float distance = Vector3.Distance(transform.position, e.transform.position);
            if (distance < closest)
            {
                tempTarget = e;
                closest = distance;
            }
        }
    }
}
