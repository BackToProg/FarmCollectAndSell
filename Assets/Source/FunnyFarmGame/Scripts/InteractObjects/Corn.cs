using Source.Modules.Infrastructure.Actions;
using UnityEngine;

namespace Source.FunnyFarmGame.Scripts.InteractObjects
{
    public class Corn : MonoBehaviour, IInteractable
    {
        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}