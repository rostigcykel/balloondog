using System;
using System.IO;
using Assets.Code.DoggieComponents;
using Assets.Code.InputHelpers;
using UnityEngine;

namespace Assets.Code.Entities.Doggie
{
    public class DoggieController : MonoBehaviour
    {
        private bool isCharging = false;

        private Rigidbody2D rigidBody;
        private Color originalColor;
        private UnlimitedSwipes inputBehaviour;

        public float currentCharge = 0.0f;
        public float currentAcceleration = 0.0f;
        public float accelerationModifier;
        public float chargeModifier;
        public float chargeMax;
        public bool stopOnChargeEnabled;
        
        public float slowMotionFactor = 0.2f;
        public float slowMotionDuration = 3f;
        
        // Use this for initialization
        void Start ()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            inputBehaviour = GetComponent<UnlimitedSwipes>();

            originalColor = renderer.material.color;
        }
	
        // Update is called once per frame
        void Update () {
	        if(isCharging)
	        {
                var mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	            var distance = Math.Abs(Vector2.Distance(transform.position, mouseWorldPosition));
	            currentCharge =  distance * chargeModifier;


	            var deltaTime = Time.deltaTime;
                
                var x = deltaTime / slowMotionDuration;
                
	            var diff = 1f - slowMotionFactor;

                
	            var timeScale = diff*x;
	            timeScale *= 3.0f;
	            
	            Time.timeScale = Math.Min(1f, Time.timeScale + timeScale);
	        }

            if(Input.GetKeyDown(KeyCode.R))
            {
                Respawn();
            }

            if(Input.GetKeyDown(KeyCode.T))
            {
                var directoryPath = "C:/Users/rostigcykel/Desktop/Project Dawg/";
                if (!Directory.Exists("C:/Users/rostigcykel/Desktop/Project Dawg/"))
                {
                    Directory.CreateDirectory("C:/Users/rostigcykel/Desktop/Project Dawg/");
                }
                Application.CaptureScreenshot("C:/Users/rostigcykel/Desktop/Project Dawg/" + DateTime.Now.ToString("yyyy-MM-dd HH-mm") + ".png");
            }
        }

        void OnFire()
        {
            Time.timeScale = 1.0f;
            ResetForce();
            isCharging = false;
            renderer.material.color = originalColor;
            var mousePosition = Input.mousePosition;
            mousePosition.z = 10;

            var mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 0;

            var acceleration = currentCharge * accelerationModifier;
            currentAcceleration = acceleration;

            var direction = transform.position - mouseWorldPosition;

            var force = direction.normalized * acceleration;

            rigidBody.AddForce(force);

            currentCharge = 0f;

            BroadcastMessage("OnPlayerChargeStop");
            inputBehaviour.StopShoot();
        }

        void OnDeath()
        {
            Respawn();
        }

        void Respawn()
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        void ResetForce()
        {
            if(stopOnChargeEnabled)
            {
                rigidBody.isKinematic = false;
            }

            rigidBody.velocity = rigidBody.velocity * slowMotionFactor;
        }
        void OnMouseDown()
        {
            if (inputBehaviour.CanShoot())
            {
                inputBehaviour.StartShoot();
                isCharging = true;
                if (stopOnChargeEnabled)
                {
                    rigidBody.isKinematic = true;
                }


                Time.timeScale = slowMotionFactor;
            }
        }

        void OnMouseUp()
        {
            if(isCharging)
            {
                OnFire();
            }
        }
    }
}
