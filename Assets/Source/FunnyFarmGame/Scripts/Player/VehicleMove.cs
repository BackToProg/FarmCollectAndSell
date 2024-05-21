using Source.Modules.Data;
using Source.Modules.Infrastructure.Services;
using Source.Modules.Infrastructure.Services.Input;
using Source.Modules.Infrastructure.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.FunnyFarmGame.Scripts.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class VehicleMove : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private float _movementSpeed = 4.0f;
        [SerializeField] private float _rotationSpeed = 0.05f;

        private IInputService _input;
        private Camera _camera;
        private CharacterController _characterController;

        private void Awake()
        {
            _input = AllServices.Container.Single<IInputService>();
            _characterController = GetComponent<CharacterController>();
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;
            
            if (_input.Axis.sqrMagnitude > Mathf.Epsilon)
            {
                movementVector = _camera.transform.TransformDirection(_input.Axis);
                movementVector.z = movementVector.y;
                movementVector.y = 0;
                movementVector.Normalize();
                
               
               Quaternion rotation = Quaternion.LookRotation(movementVector);
               transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
            }

            movementVector += Physics.gravity;
            
            _characterController.Move(movementVector * (_movementSpeed * Time.deltaTime));
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.WorldData.PositionOnLevel =
                new PositionOnLevel(GetCurrentLevel(), transform.position.AsVectorData());
        }
            

        public void LoadProgress(PlayerProgress progress)
        {
            if (GetCurrentLevel() == progress.WorldData.PositionOnLevel.Level)
            {
                Vector3Data savedPosition = progress.WorldData.PositionOnLevel.Position;
                if (savedPosition != null) 
                    Warp(savedPosition);
            }
        }

        private void Warp(Vector3Data to)
        {
            _characterController.enabled = false; // To avoid problems with CC moovement
            transform.position = to.AsUnityVector();
            _characterController.enabled = true;
        }

        private static string GetCurrentLevel() =>
            SceneManager.GetActiveScene().name;
    }
}