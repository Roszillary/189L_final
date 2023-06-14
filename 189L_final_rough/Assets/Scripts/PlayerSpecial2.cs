using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Command;

namespace Player.Command
{
    public class PlayerSpecial2 : MonoBehaviour, IPlayerCommand
    {
        [SerializeField] private float dashAmount;
        [SerializeField] private float cooldown;
        private GameObject player;

        private float cooldownTimer;
        private float direction;

        void Start()
        {
            this.cooldownTimer = Mathf.Infinity;
            this.direction = 1.0f;
        }

        void Update()
        {
            this.cooldownTimer += Time.deltaTime;
        }

        public void Execute(GameObject gameObject)
        {
            if(this.cooldownTimer >= this.cooldown)
            {
                this.cooldownTimer = 0.0f;

                this.player = gameObject;
                SetDirection();

                if(this.direction > 0)
                {
                    var playerPosition = gameObject.transform.position;
                    gameObject.transform.position = new Vector2(playerPosition.x + dashAmount, playerPosition.y);
                }
                else if(this.direction < 0)
                {
                    var playerPosition = gameObject.transform.position;
                    gameObject.transform.position = new Vector2(playerPosition.x - dashAmount, playerPosition.y);
                }

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