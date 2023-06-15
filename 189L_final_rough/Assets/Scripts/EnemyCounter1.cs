using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.Command;

namespace Enemy.Command
{
    public class EnemyCounter1 : MonoBehaviour, IEnemyCommand
    {
        [SerializeField] private float damage;
        [SerializeField] private float projectileSpeed;
        [SerializeField] private Transform projPoint;
        [SerializeField] private GameObject projectile;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void Execute(GameObject gameObject)
        {
            Debug.Log("Attack");
            //projectile.transform.position = new Vector2(projPoint.position.x, projPoint.position.y);
            //projectile.GetComponent<Projectile>().Fire(-1.0f * projectileSpeed, 0.0f);
        }
    }
}