using UnityEngine;

namespace Assets.Code.Entities.Doggie
{
    public class TailController : MonoBehaviour
    {
        private DoggieController doggie;

        /// <summary>
        /// This
        /// </summary>
        public float growRate = 1.0f;

        private Vector3 defaultScale;
        // Use this for initialization
        void Start()
        {
            doggie = GameObject.Find("Player").GetComponent<DoggieController>();
            defaultScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        // Update is called once per frame
        void Update()
        {
            var scaleX = 1 + doggie.currentCharge*growRate;
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }

        void OnPlayerChargeStop()
        {
            transform.localScale = defaultScale;
        }
    }
}
