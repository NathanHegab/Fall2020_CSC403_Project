using System;
using System.Drawing;


namespace Fall2020_CSC403_Project.code {

  public class HealthPack : Character {
    public Image Img { get; set; }

    public int HealthPoints { get; private set; }
    
    public HealthPack(Vector2 initPos, Collider collider, int healthPoints) : base(initPos, collider) {
      HealthPoints = healthPoints;
    }

    public void EmptyHealthPack() {
      HealthPoints = 0;
    } 
  }
}