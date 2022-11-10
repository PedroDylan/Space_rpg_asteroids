using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private int points = 20;
    private float probability;
    public float treshold;

    public HealthBar healthBar;
    public GameManager manager;
    public GameObject PowerPrefab;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        manager =  FindObjectOfType<GameManager>();

        probability = Random.Range(0f, 1f);

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        manager.AddPoints(points);

        if(probability <= treshold)
        {
            Instantiate(PowerPrefab,new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,0),Quaternion.identity);
        }
    }
}
