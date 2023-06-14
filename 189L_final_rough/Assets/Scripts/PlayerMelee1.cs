using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Command
{
    public class PlayerMelee1 : MonoBehaviour, IPlayerCommand
    {
        // Start is called before the first frame update
        /*void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        */

        public void Execute(GameObject gameObject)
        {
            Debug.Log("Attack");
        }
    }
}
