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
    
    [SerializeField] public HealthBarController healthBar;
    [SerializeField] private float maxHealth;
    [SerializeField] private float health;

    private Rigidbody2D body;

    private bool isGrounded;

    void Start()
    {
        this.right = ScriptableObject.CreateInstance<MoveCharacterRight>();
        this.left = ScriptableObject.CreateInstance<MoveCharacterLeft>();
        this.jump = ScriptableObject.CreateInstance<MoveCharacterJump>();
        this.fire1 = this.GetComponent<PlayerAttack1>();
        this.fire2 = this.GetComponent<PlayerAttack2>();
        this.fire3 = this.GetComponent<PlayerAttack3>();
        //this.Q = this.GetComponent<PlayerMelee1>();
        //this.Q = this.GetComponent<PlayerSpecial1>();
        this.Q = this.GetComponent<PlayerSpecial2>();
        this.E = this.GetComponent<PlayerMelee2>();

        this.healthBar.SetMaxHealth(maxHealth);
        this.healthBar.SetHealth(0.0f);

        this.isGrounded = true;
    }

    void Update()
    {
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
            Debug.Log("hit");
            this.isGrounded = true;
        }
    }
}
