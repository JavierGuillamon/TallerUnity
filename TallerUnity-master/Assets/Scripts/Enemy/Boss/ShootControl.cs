using UnityEngine;
using System.Collections;

public class ShootControl : MonoBehaviour {

    public Transform muzzle;
    public Projectile projectile;
    public float velocidadBala;
    float nextShotTime;
    public void Shoot()
    {
        projectile.setSpeed(new Vector2(0, velocidadBala));
           
    }
}
