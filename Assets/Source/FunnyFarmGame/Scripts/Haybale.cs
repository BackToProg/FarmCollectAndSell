using UnityEngine;

namespace Source.FunnyFarmGame.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Haybale : MonoBehaviour
    {
        private Rigidbody rb;
        
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            // if (Input.GetKey(KeyCode.A))
            // {
            //     rb.velocity = new Vector3(-5, 10, 0);
            // }
        }
    }
}
