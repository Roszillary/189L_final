using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Command;

public class PlayerController : MonoBehaviour
{

    private IPlayerCommand right;
    private IPlayerCommand left;
    private IPlayerCommand jump;
    private IPlayerCommand fire1;
    private IPlayerCommand fire2;
    private IPlayerCommand fire3;
    private IPlayerCommand Q;
    private IPlayerCommand E;

    private int currentAbility;
    private int currentAbilities;
    
    [SerializeField] public HealthBarController healthBar;
    [SerializeField] private float maxHealth;
    [SerializeField] private float health;

    private float abilitySwapCooldown;
    private float abilitySwapTimer;

    private Rigidbody2D body;

    private bool isGrounded;

    void Start()
    {
        this.right = ScriptableObject.CreateInstance<MoveCharacterRight>();
        this.left = ScriptableObject.CreateInstance<MoveCharacterLeft>();
        this.jump = ScriptableObject.CreateInstance<MoveCharacterJump>();

        this.currentAbility = 1;
        this.currentAbilities = 1;
        SetAbility(); 
        
        this.abilitySwapCooldown = 2.0f;
        this.abilitySwapTimer = Mathf.Infinity;

        this.healthBar.SetMaxHealth(maxHealth);
        this.healthBar.SetHealth(0.0f);

        this.isGrounded = true;
    }

    void Update()
    {
        this.abilitySwapTimer += Time.deltaTime;

        if(Input.GetAxis("Horizontal") > 0.01)
        {
            this.right.Execute(this.gameObject);
        }
        if(Input.GetAxis("Horizontal") < -0.01)
        {
            this.left.Execute(this.gameObject);
        }
        if(Input.GetKey(KeyCode.Space) && this.isGrounded)
        {
            this.jump.Execute(this.gameObject);
            this.isGrounded = false;
        }
        if(Input.GetMouseButton(0))
        {
            this.fire1.Execute(this.gameObject);
        }

        if(Input.GetKey(KeyCode.Return))
        {
            if(this.abilitySwapTimer >= this.abilitySwapCooldown)
            {
                this.abilitySwapTimer = 0.0f;

                this.currentAbilities += 1; 
                if(this.currentAbilities == 4)
                    this.currentAbilities = 1;
                this.currentAbility = 1;
                SetAbility(); 
            }
        }
        
        if(Input.GetKey(KeyCode.Alpha1))
        {
            if(this.abilitySwapTimer >= this.abilitySwapCooldown)
            {
                this.abilitySwapTimer = 0.0f;
                this.currentAbility = 1;
                SetAbility(); 
            }
        }
        if(Input.GetKey(KeyCode.Alpha2))
        {
            if(this.abilitySwapTimer >= this.abilitySwapCooldown)
            {
                this.abilitySwapTimer = 0.0f;
                this.currentAbility = 2;
                SetAbility(); 
            }
        }
        if(Input.GetKey(KeyCode.Alpha3))
        {
            if(this.abilitySwapTimer >= this.abilitySwapCooldown)
            {
                this.abilitySwapTimer = 0.0f;
                this.currentAbility = 3;
                SetAbility(); 
            }
        }
    }

    void SetAbility()
    {
        //Debug.Log((this.currentAbility, this.currentAbilities));
        if(this.currentAbilities == 1)
        {
            switch (this.currentAbility)
            {
                case 1:
                    Debug.Log("Tap");
                    this.fire1 = this.GetComponent<PlayerAttack1>();
                    break;
                case 2:
                    Debug.Log("Burst");
                    this.fire1 = this.GetComponent<PlayerAttack2>();
                    break;
                case 3:
                    Debug.Log("Spray");
                    this.fire1 = this.GetComponent<PlayerAttack3>();
                    break;
                default:
                    break;
            }
        }
        else if(this.currentAbilities == 2)
        {
            switch (this.currentAbility)
            {
                case 1:
                    Debug.Log("Knife");
                    this.fire1 = this.GetComponent<PlayerMelee1>();
                    break;
                case 2:
                    Debug.Log("Bash");
                    this.fire1 = this.GetComponent<PlayerMelee2>();
                    break;
                default:
                    break;
            }
        }
        else if(this.currentAbilities == 3)
        {
            switch (this.currentAbility)
            {
                case 1:
                    Debug.Log("Heal");
                    this.fire1 = this.GetComponent<PlayerSpecial1>();
                    break;
                case 2:
                    Debug.Log("Dash/TP");
                    this.fire1 = this.GetComponent<PlayerSpecial2>();
                    break;
                default:
                    break;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        this.health -= damage;
        this.healthBar.SetHealth(this.health);

        if(this.health <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }

    public void Heal(float healAmount)
    {
        this.health += healAmount;
        if(this.health > this.maxHealth)
            this.health = this.maxHealth;
        this.healthBar.SetHealth(this.health);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Ground")
        {
            this.isGrounded = true;
        }
    }
}


// Old Code.

//this.fire1 = this.GetComponent<PlayerAttack1>();
//this.fire2 = this.GetComponent<PlayerAttack2>();
//this.fire3 = this.GetComponent<PlayerAttack3>();
//this.Q = this.GetComponent<PlayerMelee1>();
//this.Q = this.GetComponent<PlayerSpecial1>();
//this.Q = this.GetComponent<PlayerSpecial2>();
//this.E = this.GetComponent<PlayerMelee2>();


/*
if(Input.GetMouseButton(1))
{
    this.fire2.Execute(this.gameObject);
}
if(Input.GetMouseButton(2))
{
    this.fire3.Execute(this.gameObject);
}
if(Input.GetKey(KeyCode.Q))
{
    this.Q.Execute(this.gameObject);
}
if(Input.GetKey(KeyCode.E))
{
    this.E.Execute(this.gameObject);
}*/