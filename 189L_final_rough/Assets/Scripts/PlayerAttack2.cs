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
        [SerializeField] private float burstCooldown;
        [SerializeField] private Transform projPoint;
        [SerializeField] private GameObject[] projectiles;

        private GameObject player;

        private float cooldownTimer;
        private float burstCooldownTimer;
        private int burstIter;
        private bool bursting;
        private float direction;

        void Start()
        {
            cooldownTimer = Mathf.Infinity;
            burstCooldownTimer = Mathf.Infinity;
            burstIter = 0;
            bursting = false;
            this.direction = 1.0f;
        }

        void Update()
        {
            cooldownTimer += Time.deltaTime;
            burstCooldownTimer += Time.deltaTime;
            
            if(burstIter >= 3)
            {
                bursting = false;
            }

            if(burstCooldownTimer >= burstCooldown && bursting == true)
            {
                burstCooldownTimer = 0.0f;
                burstIter++;

                SetDirection();
                var playerPosition = this.player.transform.position;
                var projIndex = FindProjectile();

                Debug.Log(this.direction);

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

        public void Execute(GameObject gameObject)
        {
            if(cooldownTimer >= cooldown)
            {
                cooldownTimer = 0.0f;
                burstIter = 0;
                bursting = true;

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
