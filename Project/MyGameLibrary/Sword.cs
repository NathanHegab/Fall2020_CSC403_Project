using System.Drawing;

namespace Fall2020_CSC403_Project.code
{
    public class Sword
    {
        public string swordDescription;
        public Image swordPicture;
        public int damage;

        public Vector2 Vector2 { get; }
        public Collider Collider { get; }

        public Sword(Vector2 initPos, Collider collider, string description, Image swordPic, int damage)
        {
            Vector2 = initPos;
            Collider = collider;
            this.swordDescription = description;
            this.swordPicture = swordPic;
            this.damage = damage;
        }
    }
}
