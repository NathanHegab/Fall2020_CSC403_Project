using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fall2020_CSC403_Project.code {
    public class Character {
        private const int GO_INC = 3;
        private const float GO_INC_SNEAK = 1.5f;
        private const int GO_INC_SPRINT = 5;

        public Vector2 MoveSpeed { get; private set; }
        public Vector2 LastPosition { get; private set; }
        public Vector2 Position { get; private set; }
        public Collider Collider { get; private set; }

        public Character(Vector2 initPos, Collider collider) {
            Position = initPos;
            Collider = collider;
        }

        public void Move() {
            LastPosition = Position;
            Position = new Vector2(Position.x + MoveSpeed.x, Position.y + MoveSpeed.y);
            Collider.MovePosition((int)Position.x, (int)Position.y);
        }

        public void MoveBack() {
            Position = LastPosition;
        }
        public void GoLeft() {
            MoveSpeed = new Vector2(-GO_INC, 0);
        }
        public void GoSprintLeft() {
            MoveSpeed = new Vector2(-GO_INC_SPRINT, 0);
        }
        public void GoSneakLeft() {
            MoveSpeed = new Vector2(-GO_INC_SNEAK, 0);
        }
        public void GoRight() {
            MoveSpeed = new Vector2(+GO_INC, 0);
        }
        public void GoSprintRight() {
            MoveSpeed = new Vector2(+GO_INC_SPRINT, 0);
        }
        public void GoSneakRight() {
            MoveSpeed = new Vector2(+GO_INC_SNEAK, 0);
        }
        public void GoUp() {
            MoveSpeed = new Vector2(0, -GO_INC);
        }
        public void GoSprintUp() {
            MoveSpeed = new Vector2(0, -GO_INC_SPRINT);
        }
        public void GoSneakUp() {
            MoveSpeed = new Vector2(0, -GO_INC_SNEAK);
        }
        public void GoDown() {
            MoveSpeed = new Vector2(0, +GO_INC);
        }
        public void GoSprintDown() {
            MoveSpeed = new Vector2(0, +GO_INC_SPRINT);
        }
        public void GoSneakDown() {
            MoveSpeed = new Vector2(0, +GO_INC_SNEAK);
        }
        public void ResetMoveSpeed() {
            MoveSpeed = new Vector2(0, 0);
        }
    }
}
