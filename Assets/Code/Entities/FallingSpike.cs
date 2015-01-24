using System;
using Assets.Code.Constants;
using UnityEngine;

namespace Assets.Code.Entities
{
    public class FallingSpike : MonoBehaviour
    {
        public float waitTimeBeforeFalling;
        private bool isActive;
        private bool isFalling;
        private float fallTimer;

        void Start()
        {
            rigidbody2D.isKinematic = true;
        }

        void Update()
        {
            if(isActive)
            {
                if (isFalling)
                {
                    rigidbody2D.isKinematic = false;
                }
                else
                {
                    fallTimer += Time.deltaTime;

                    if (fallTimer > waitTimeBeforeFalling)
                    {
                        isFalling = true;
                    }
                }
            }
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            var targetGameObject = collider.gameObject;

            if (targetGameObject.tag.Equals(PlayerConstants.PlayerTag, StringComparison.OrdinalIgnoreCase))
            {
                Debug.Log("Falling spike TRIGGER");
                isActive = true;
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var targetGameObject = collision.gameObject;
            if (targetGameObject.tag.Equals(PlayerConstants.PlayerTag, StringComparison.OrdinalIgnoreCase))
            {
                Debug.Log("Falling spike COLLISION");
                targetGameObject.SendMessage("OnDeath");
            }
        }
    }
}
