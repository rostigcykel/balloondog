using System;
using Assets.Code.Constants;
using UnityEngine;

namespace Assets.Code.Entities
{
    public class WreckingBall : MonoBehaviour
    {
        public float angle;
        public float period;
        private float time;

        void Start()
        {
        }

        void Update()
        {
            time = time + Time.deltaTime;
            float phase = Mathf.Sin(time / period);
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, phase * angle));       
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var targetGameObject = collision.gameObject;

            if (targetGameObject.tag.Equals(PlayerConstants.PlayerTag, StringComparison.OrdinalIgnoreCase))
            {
                Debug.Log("Wrecking Ball Collision");
                targetGameObject.SendMessage("OnDeath");
            }
        }
    }
}
