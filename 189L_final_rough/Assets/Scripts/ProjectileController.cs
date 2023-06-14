using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float cooldown;
    private float cooldownTimer;

    // Start is called before the first frame update
    void Start()
    {
        //cooldownTimer = Mathf.Infinity;
        cooldownTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if(cooldownTimer >= cooldown)
        {
            //cooldownTimer = 0.0f;
            //GetComponent<Projectile>().Fire();
        }
    }
}
