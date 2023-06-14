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

    private Rigidbody2D body;

    private bool isGrounded;

    void Start()
    {
        this.right = ScriptableObject.CreateInstance<MoveCharacterRight>();
        this.left = ScriptableObject.CreateInstance<MoveCharacterLeft>();
        this.jump = ScriptableObject.CreateInstance<MoveCharacterJump>();
        this.fire1 = this.GetComponent<PlayerAttack1>();
        this.fire2 = this.GetComponent<PlayerAttack2>();

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
