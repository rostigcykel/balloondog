using System;
using Assets.Code.Constants;
using UnityEngine;

namespace Assets.Code.Entities
{
    public class Deactivator : MonoBehaviour
    {
        /// <summary>
        /// When the deactivator collides with the player this gameObject will be removed.
        /// </summary>
        public GameObject deactivatorTarget;

        void Start()
        {
            
        }

        void Update()
        {
            
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            var targetGameObject = collider.gameObject;

            if (targetGameObject.tag.Equals(PlayerConstants.PlayerTag, StringComparison.OrdinalIgnoreCase))
            {
                Debug.Log("Deactivator Collision");
                Destroy(deactivatorTarget);
            }
        }
    }
}
