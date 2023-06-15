using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.Command;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public HealthBarController healthBar;

    private float maxHealth;
    private float health;
    private IEnemyCommand ability;
    [SerializeField] private float cooldown;
    private float cooldownTimer;

    void Start()
    {
        this.cooldownTimer = Mathf.Infinity;

        this.maxHealth = 100.0f;
        this.health = 100.0f;

        this.ability = this.GetComponent<EnemyCounter1>();

        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        this.cooldownTimer += Time.deltaTime;

        if(this.cooldownTimer >= this.cooldown)
        {
            this.cooldownTimer = 0.0f;

            this.ability.Execute(this.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {

        this.health -= damage;
        healthBar.SetHealth(health);
        
        if(this.health <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }
    
}
