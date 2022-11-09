using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //recebendo a bala e o ponto de atirar
    public GameObject ShootPrefab;
    public Transform FirePoint;

    public float bulletForce;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        //instanciando a cala recebida no firepoint com a respectiva rotação
        GameObject bullet = Instantiate(ShootPrefab,FirePoint.position,FirePoint.rotation);
        
        //lendo o corpo da bala para poder adicionar força a ele 
        Rigidbody2D rigidBody2d = bullet.GetComponent<Rigidbody2D>();
        rigidBody2d.AddForce(FirePoint.up * bulletForce,ForceMode2D.Impulse);
    }
}
