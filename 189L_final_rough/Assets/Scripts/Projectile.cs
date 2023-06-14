using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private float lifetime;

    void Start()
    {
        
    }

    void Update()
    {
        var projPosition = this.transform.position;
        this.transform.position = new Vector2(projPosition.x + this.speed * this.direction * Time.deltaTime, projPosition.y);
        
        this.lifetime += Time.deltaTime;
        if (this.lifetime > 5.0f) gameObject.SetActive(false);
    }

    public void Fire(float direction)
    {
        this.direction = direction;
        this.lifetime = 0;
        gameObject.SetActive(true);
    }

}
