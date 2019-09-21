using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageManager : MonoBehaviour
{
    public float physicalResistance;
    public float magicResistance;

    private Hashtable typeMap = new Hashtable();

    private void Start()
    {
        refreshResistances();
    }

    public void takeDamage(float flatDamage, string type)
    {
        float resistance = (float)typeMap[type];
        float damageAmount = flatDamage - (flatDamage / 100) * resistance;
        this.GetComponent<Enemy>().currentHealth -= damageAmount;
    }

    public void refreshResistances()
    {
        typeMap.Add("Physical", physicalResistance);
        typeMap.Add("Magic", magicResistance);
    }
}
