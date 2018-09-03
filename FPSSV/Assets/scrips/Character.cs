using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    public float life;
    public float armor;
    private float Clife;
    private float Carmor;


    public abstract void takeDmg(float dmg);
}
