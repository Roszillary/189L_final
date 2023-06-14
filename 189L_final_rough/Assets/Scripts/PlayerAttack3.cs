using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Command;

namespace Player.Command
{
    public class PlayerAttack3 : MonoBehaviour, IPlayerCommand
    {
        [SerializeField] private float damage;
        [SerializeField] private float cooldown;
        [SerializeField] private float projectileSpeed;
        [SerializeField] private Transform projPoint;
        [SerializeField] private GameObject[] projectiles;

        private GameObject player;
        private Transform playerPosition;

        private float cooldownTimer;
        private float direction;

        private int sprayIter;
        private bool spraying;

        void Start()
        {
            this.cooldownTimer = Mathf.Infinity;
            this.direction = 1.0f;

            this.sprayIter = 0;
            this.spraying = false;
        }

        void Update()
        {
            this.cooldownTimer += Time.deltaTime;
            
            if(this.sprayIter >= 3)
            {
                this.spraying = false;
            }

            if(this.spraying == true)
            {
                this.sprayIter++;

                var spread = 0;
                if(this.sprayIter == 1)
                    spread = 1;
                else if(this.sprayIter == 2)
                    spread = -1;

                SetDirection();
                var playerPosition = this.playerPosition.position;
                var projIndex = FindProjectile();

                if(this.direction > 0)
                {
                    projectiles[projIndex].transform.position = new Vector2(projPoint.position.x, projPoint.position.y + spread);
                    projectiles[projIndex].GetComponent<Projectile>().Fire(1.0f * projectileSpeed, spread * projectileSpeed * 5);
                }
                else if(this.direction < 0)
                {
                    projectiles[projIndex].transform.position = new Vector2(playerPosition.x - (projPoint.position.x - playerPosition.x), projPoint.position.y + spread);
                    projectiles[projIndex].GetComponent<Projectile>().Fire(-1.0f * projectileSpeed, spread * projectileSpeed * 5);
                }

            }
        }

        public void Execute(GameObject gameObject)
        {
            if(this.cooldownTimer >= this.cooldown)
            {
                this.cooldownTimer = 0.0f;
                this.sprayIter = 0;
                this.spraying = true;

                this.playerPosition = gameObject.transform;
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
