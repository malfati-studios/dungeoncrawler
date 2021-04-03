using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerController))]
    public class PlayerInput : MonoBehaviour
    {
        public KeyCode forward = KeyCode.W;
        public KeyCode back = KeyCode.S;
        public KeyCode left = KeyCode.A;
        public KeyCode right = KeyCode.D;
        public KeyCode turnLeft = KeyCode.Q;
        public KeyCode turnRight = KeyCode.E;
        private PlayerController _controller;

        private void Awake()
        {
            _controller = GetComponent<PlayerController>();
        }

        private void Update()
        {
            if(Input.GetKeyUp(forward)) _controller.MoveForward();
            if(Input.GetKeyUp(back)) _controller.MoveBackwards();
            if(Input.GetKeyUp(left)) _controller.MoveLeft();
            if(Input.GetKeyUp(right)) _controller.MoveRight();
            if(Input.GetKeyUp(turnLeft)) _controller.RotateLeft();
            if(Input.GetKeyUp(turnRight)) _controller.RotateRight();
        }
    }
}

