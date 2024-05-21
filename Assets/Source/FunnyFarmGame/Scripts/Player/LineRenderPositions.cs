using UnityEngine;

namespace Source.FunnyFarmGame.Scripts.Player
{
    [RequireComponent(typeof(LineRenderer))]
    public class LineRenderPositions : MonoBehaviour
    {
        [SerializeField] private Transform _point1;
        [SerializeField] private Transform _point2;

        private LineRenderer _lineRenderer;
        private readonly Vector3[] _positions = new Vector3[2];

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _positions[0] = _point1.position;
            _positions[1] = _point2.position;
            _lineRenderer.positionCount = _positions.Length;
        }

        private void Update()
        {
            _lineRenderer.SetPositions(_positions);
        }
    }
}
