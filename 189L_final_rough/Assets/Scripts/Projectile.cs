using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private float ySpeed;

    private float lifetime;
    private bool startFire;

    void Start()
    {
        this.startFire = true;
    }

    void Update()
    {
        if(!this.startFire)
            return;

        var projPosition = this.transform.position;
        this.transform.position = new Vector2(projPosition.x + this.speed * this.direction * Time.deltaTime, projPosition.y + this.ySpeed * Time.deltaTime);
        
        this.lifetime += Time.deltaTime;
        if (this.lifetime > 5.0f) gameObject.SetActive(false);
    }

    public void SetFire(bool startFire)
    {
        this.startFire = startFire;
    }

    public void Fire(float direction, float ySpeed)
    {
        this.direction = direction;
        this.ySpeed = ySpeed;

        this.lifetime = 0;
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(20);
            //Destroy(collision.gameObject);
            this.gameObject.SetActive(false);
        }
    }

}
