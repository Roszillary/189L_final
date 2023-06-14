using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public HealthBarController healthBar;

    private float maxHealth;
    private float health;

    void Start()
    {
        this.maxHealth = 100.0f;
        this.health = 100.0f;

        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        this.health -= damage;
        healthBar.SetHealth(health);

        Debug.Log(this.health);

        if(this.health <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }
    
}
