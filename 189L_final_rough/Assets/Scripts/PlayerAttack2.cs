using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Command;

namespace Player.Command
{
    public class PlayerAttack2 : MonoBehaviour, IPlayerCommand
    {
        [SerializeField] private float damage;
        [SerializeField] private float cooldown;
        [SerializeField] private float projectileSpeed;
        [SerializeField] private Transform projPoint;
        [SerializeField] private GameObject[] projectiles;
        [SerializeField] private float burstCooldown;

        private GameObject player;

        private float cooldownTimer;
        private float direction;

        private float burstCooldownTimer;
        private int burstIter;
        private bool bursting;

        void Start()
        {
            this.cooldownTimer = Mathf.Infinity;
            this.direction = 1.0f;

            this.burstCooldownTimer = Mathf.Infinity;
            this.burstIter = 0;
            this.bursting = false;
        }

        void Update()
        {
            this.cooldownTimer += Time.deltaTime;
            this.burstCooldownTimer += Time.deltaTime;
            
            if(this.burstIter >= 3)
            {
                this.bursting = false;
            }

            if(this.burstCooldownTimer >= this.burstCooldown && this.bursting == true)
            {
                this.burstCooldownTimer = 0.0f;
                this.burstIter++;

                SetDirection();
                var playerPosition = this.player.transform.position;
                var projIndex = FindProjectile();

                if(this.direction > 0)
                {
                    projectiles[projIndex].transform.position = new Vector2(projPoint.position.x, projPoint.position.y);
                    projectiles[projIndex].GetComponent<Projectile>().Fire(1.0f * projectileSpeed, 0.0f);
                }
                else if(this.direction < 0)
                {
                    projectiles[projIndex].transform.position = new Vector2(playerPosition.x - (projPoint.position.x - playerPosition.x), projPoint.position.y);
                    projectiles[projIndex].GetComponent<Projectile>().Fire(-1.0f * projectileSpeed, 0.0f);
                }

            }
        }

        public void Execute(GameObject gameObject)
        {
            if(this.cooldownTimer >= this.cooldown)
            {
                this.cooldownTimer = 0.0f;
                this.burstIter = 0;
                this.bursting = true;

                this.player = gameObject;
            }
        }

        private void SetDirection()
        {
            var rigidBody = this.player.GetComponent<Rigidbody2D>();
            var velocity = rigidBody.velocity;
            var right = this.player.transform.right;
            float dotProduct = Vector2.Dot(velocity.normalized, right);
            if(dotProduct != 0.0f) this.direction = dotProduct;
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
