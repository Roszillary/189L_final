using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Command;

namespace Player.Command
{
    public class PlayerAttack1 : MonoBehaviour, IPlayerCommand
    {
        [SerializeField] private float damage;
        [SerializeField] private float cooldown;
        [SerializeField] private Transform projPoint;
        [SerializeField] private GameObject[] projectiles;

        private float cooldownTimer;
        private float direction;

        void Start()
        {
            cooldownTimer = Mathf.Infinity;
            direction = 1.0f;
        }

        void Update()
        {
            cooldownTimer += Time.deltaTime;
        }

        public void Execute(GameObject gameObject)
        {
            if(cooldownTimer >= cooldown)
            {
                cooldownTimer = 0.0f;
                var projIndex = FindProjectile();

                var rigidBody = gameObject.GetComponent<Rigidbody2D>();
                var velocity = rigidBody.velocity;
                var right = gameObject.transform.right;
                float dotProduct = Vector2.Dot(velocity.normalized, right);
                if(dotProduct != 0.0f) this.direction = dotProduct;

                var playerPosition = gameObject.transform.position;
                
                if(this.direction > 0)
                {
                    projectiles[projIndex].transform.position = new Vector2(projPoint.position.x, projPoint.position.y);
                    projectiles[projIndex].GetComponent<Projectile>().Fire(1.0f);
                }
                else if(this.direction < 0)
                {
                    projectiles[projIndex].transform.position = new Vector2(playerPosition.x - (projPoint.position.x - playerPosition.x), projPoint.position.y);
                    projectiles[projIndex].GetComponent<Projectile>().Fire(-1.0f);
                }
            }
        }

        private int FindProjectile()
        {
            for (int i = 0; i < projectiles.Length; i++)
            {
                if (!projectiles[i].activeInHierarchy)
                    return i;
            }
            return 0;
        }

    }
}
