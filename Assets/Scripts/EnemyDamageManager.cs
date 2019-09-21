using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageManager : MonoBehaviour
{
    public float physicalResistance;
    public float magicResistance;
    public Playstat HP;

    private Hashtable typeMap = new Hashtable();

    private void Start()
    {
        refreshResistances();
    }

    public float takeDamage(float flatDamage, string type)
    {
        float resistance = (float)typeMap[type];
        float damageAmount = flatDamage - (flatDamage / 100) * resistance;
        return damageAmount;
    }

    public void refreshResistances()
    {
        typeMap.Add("Physical", physicalResistance);
        typeMap.Add("Magic", magicResistance);
    }
}
