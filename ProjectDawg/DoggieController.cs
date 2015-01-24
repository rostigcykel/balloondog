using Assets.Code.InputHelpers;
using UnityEngine;

namespace Assets.Code.Doggie
{
    public class DoggieController : MonoBehaviour
    {
        private bool isCharging = false;
        private Rigidbody2D rigidBody;
        private GameObject body;
        private Color originalColor;


        public float accelerationModifier;

        // Use this for initialization
        void Start ()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            body = transform.FindChild("body").gameObject;
            originalColor = body.renderer.material.color;
        }
	
        // Update is called once per frame
        void Update () {
	        if(isCharging)
	        {
                if(Input.GetMouseButtonUp(InputConstants.MouseButtonLeft))
                {
                    OnDoggieFire();
                }
	        }
        }

        private void OnDoggieFire()
        {
            isCharging = false;
            body.renderer.material.color = originalColor;
            var mousePosition = Input.mousePosition;
            mousePosition.z = 10;

            var mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("Player Position: " + transform.position);
            Debug.Log("Mouse Position: " );
            Debug.Log("x: " + mouseWorldPosition.x);
            Debug.Log("y: " + mouseWorldPosition.y);

            var acceleration = Vector2.Distance(transform.position.normalized, mouseWorldPosition.normalized) * accelerationModifier;
            Debug.Log("Acceleration: " + acceleration);

            var direction = transform.position - mousePosition;
            Debug.Log("Direction: " + direction);
            direction.x = -direction.x;
            direction.y = -direction.y;

            var force = direction.normalized * acceleration;
            Debug.Log("Force: " + force);
            rigidBody.AddForce(force);
        }


        void OnDoggieActivate()
        {
            Debug.Log("DOGGIE HAS BEEN ACTIVATED!");

            body.renderer.material.color = new Color(1, 0, 0);
            isCharging = true;
        }


        void OnMouseDown()
        {
            OnDoggieActivate();
        }
    }
}
