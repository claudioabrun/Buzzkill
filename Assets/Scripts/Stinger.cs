using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stinger : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    // Start is called before the first frame update
    public void Fire()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
