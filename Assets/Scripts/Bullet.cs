using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 20;
    float leftConstraint = Screen.width;
    float rightConstraint = Screen.width;
    float bottomConstraint = Screen.height;
    float topConstraint = Screen.height;

    Camera cam;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        if (!collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        cam = Camera.main;
        leftConstraint = cam.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        bottomConstraint = cam.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        topConstraint = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
    }

    private void FixedUpdate()
    {
        if(transform.position.x >= rightConstraint || transform.position.x <= leftConstraint || transform.position.y >= topConstraint || transform.position.y <= bottomConstraint)
        {
            Destroy(gameObject);
        }
    }
}
