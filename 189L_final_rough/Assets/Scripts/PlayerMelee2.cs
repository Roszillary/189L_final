using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Command
{
    public class PlayerMelee2 : MonoBehaviour, IPlayerCommand
    {
        [SerializeField] private float damage;
        [SerializeField] private float cooldown;

        [SerializeField] private Transform center;
        [SerializeField] private float radius;
        [SerializeField] private LayerMask Enemy;

        private GameObject player;

        private float cooldownTimer;
        private float direction;

        private bool bashing;
        

        void Start()
        {
            this.cooldownTimer = Mathf.Infinity;
            this.direction = 1.0f;

            this.bashing = false;
        }

        void Update()
        {
            this.cooldownTimer += Time.deltaTime;

            if(this.bashing)
            {
                Debug.Log("Stun");
                SetDirection();
                var playerPosition = this.player.transform.position;

                if(this.direction > 0)
                {
                    Collider2D[] enemiesHit = Physics2D.OverlapBoxAll(this.center.position, new Vector2(this.radius, this.radius), 0, this.Enemy);
                    foreach (var enemy in enemiesHit)
                    {
                        enemy.GetComponent<EnemyController>().TakeDamage(this.damage);
                    }
                }
                else if(this.direction < 0)
                {
                    var centerPosition = new Vector2(playerPosition.x - (this.center.position.x - playerPosition.x), this.center.position.y);
                    Collider2D[] enemiesHit = Physics2D.OverlapBoxAll(centerPosition, new Vector2(this.radius, this.radius), 0, this.Enemy);
                    foreach (var enemy in enemiesHit)
                    {
                        //Destroy(enemy.gameObject);
                        enemy.GetComponent<EnemyController>().TakeDamage(this.damage);
                    }
                }

                this.bashing = false;
            }
        }
        

        public void Execute(GameObject gameObject)
        {
            if(this.cooldownTimer >= this.cooldown)
            {
                this.cooldownTimer = 0.0f;
                this.bashing = true;

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

    }
}
