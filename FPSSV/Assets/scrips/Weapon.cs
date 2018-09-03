using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {

    public int tipe;
    public float fireRate;
    public int clipsize;
    public Bullet bulletslot;
    private int loadbullets;
    public GameObject shoottip;

    
    public abstract void shoot();
    public abstract void recarge();


}
