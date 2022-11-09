using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 20;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Enemy enemy = collision.collider.GetComponent<Enemy>();
        
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
