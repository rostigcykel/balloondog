using UnityEngine;

namespace Assets.Code.CameraHelper
{
    public class CameraFollower : MonoBehaviour
    {
        public GameObject target;

        public bool centerHorizontallyPlayer = true;
        public float playerDist = 10f;

        void Update()
        {
            var targetPosition = target.transform.position;
            var cameraPositionZ = Camera.main.transform.position.z;
            var cameraPositionY = centerHorizontallyPlayer ? targetPosition.y : Camera.main.transform.position.y;
            var cameraPositionX = targetPosition.x + playerDist;
            Camera.main.transform.position = new Vector3(cameraPositionX, cameraPositionY, cameraPositionZ);


        }
    }
}
