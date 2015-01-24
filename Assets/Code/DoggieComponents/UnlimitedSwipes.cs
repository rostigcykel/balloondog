using UnityEngine;

namespace Assets.Code.DoggieComponents
{
    public class UnlimitedSwipes : MonoBehaviour, IInputBehaviour
    {
        public float cooldown = 0.5f;

        private float cooldownLeft;
        private bool hasCooldown;
        public void Update()
        {
            if(hasCooldown)
            {
                cooldownLeft = Mathf.Max(0f, cooldownLeft - Time.deltaTime);
                hasCooldown = !(cooldownLeft <= 0);
                
                if(!hasCooldown)
                {
                    renderer.material.color = new Color(1f, 1f, 1f, 1f);
                }
            }
        }

        public bool CanShoot()
        {
            return !hasCooldown;
        }

        public void StartShoot()
        {
            
        }

        public void StopShoot()
        {
            hasCooldown = true;
            cooldownLeft = cooldown;
            renderer.material.color = new Color(0, 0, 1);
        }
    }
}
