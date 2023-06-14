using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Command;

namespace Player.Command
{
    public class PlayerSpecial1 : MonoBehaviour, IPlayerCommand
    {
        [SerializeField] private float healAmount;
        [SerializeField] private float cooldown;
        private float cooldownTimer;

        void Update()
        {
            this.cooldownTimer += Time.deltaTime;
        }

        public void Execute(GameObject gameObject)
        {
            if(this.cooldownTimer >= this.cooldown)
            {
                this.cooldownTimer = 0.0f;
                GetComponent<PlayerController>().Heal(healAmount);
            }
        }
    }
}