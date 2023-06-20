using UnityEngine;

namespace Coin
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;
        [SerializeField] private MeshRenderer renderer;

        private void Update()
        {
            var targetRotation = Quaternion.Euler(transform.eulerAngles + Vector3.up * rotationSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime);
        }

        public void SetRandomColor()
        {
            var randomVector = Random.onUnitSphere;
            renderer.material.color = new Color(randomVector.x, randomVector.y, randomVector.z);
        }
    }
}