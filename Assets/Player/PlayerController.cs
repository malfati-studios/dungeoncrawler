using DefaultNamespace;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public float playerHeight = 1.25f;
        public float transitionSpeed = 10f;
        public float transitionRotationSpeed = 2000f;

        private MapPosition _targetGridPos;
        private Vector3 _targetRotation;
        private LevelManager _levelManager;
        private int cellSize;

        public void RotateLeft()
        {
            if (AtRest())
            {
                _targetRotation -= Vector3.up * 90f;
            }
        }

        public void RotateRight()
        {
            if (AtRest())
            {
                _targetRotation += Vector3.up * 90f;
            }
        }

        public void MoveForward()
        {
            Move(transform.forward);
        }


        public void MoveBackwards()
        {
            Move(transform.forward * -1);
        }

        public void MoveLeft()
        {
            Move(transform.right * -1);
        }

        public void MoveRight()
        {
            Move(transform.right);
        }

        private void Move(Vector3 direction)
        {
            if (!AtRest()) return;

            MapPosition desiredPosition = CalculateDesiredPosition(direction);

            Debug.Log("Moving to " + desiredPosition.x + ", " + desiredPosition.z + " " +
                      desiredPosition.worldPosition);

            if (!_levelManager.IsValidPosition(desiredPosition)) return;
            if (_levelManager.IsThereInteractive(desiredPosition)) return;
            
            _targetGridPos = desiredPosition;
        }

        private bool AtRest()
        {
            return Vector3.Distance(transform.position, _targetGridPos.worldPosition) < .05f &&
                   Vector3.Distance(transform.eulerAngles, _targetRotation) < .05f;
        }

        private void Start()
        {
            _targetGridPos = WorldGrid.instance.GetStartingPosition();
            transform.position = _targetGridPos.worldPosition;
            _levelManager = FindObjectOfType<LevelManager>();
            cellSize = _levelManager.GetCellSize();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            if (_targetRotation.y > 270f && _targetRotation.y < 361f)
            {
                _targetRotation.y = 0f;
            }

            if (_targetRotation.y < 0f)
            {
                _targetRotation.y = 270f;
            }

            Vector3 targetPosition = _targetGridPos.worldPosition;

            transform.position =
                Vector3.MoveTowards(transform.position, targetPosition, Time.fixedDeltaTime * transitionSpeed);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(_targetRotation),
                Time.fixedDeltaTime * transitionRotationSpeed);
        }

        private MapPosition CalculateDesiredPosition(Vector3 direction)
        {
            MapPosition newPos = new MapPosition();
            newPos.x += _targetGridPos.x + (int) direction.x;
            newPos.z += _targetGridPos.z + (int) direction.z;

            newPos.worldPosition = MapUtils.CalculateWorldPosition(newPos.x, newPos.z, cellSize);
            newPos.worldPosition.y = playerHeight;
            return newPos;
        }
    }
}