using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable 1591 // use this to disable comment warnings

namespace Fall2020_CSC403_Project.code {
    public class BattleCharacter : Character {
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }
        private float strength;
        private Sword weapon;

        public event Action<int> AttackEvent;

        public BattleCharacter(Vector2 initPos, Collider collider) : base(initPos, collider) {
            MaxHealth = 20;
            strength = 2;
            weapon = null;
            Health = MaxHealth;
        }

        // adds weapon damage to the amount of damage that will be done by the player
        public void OnAttack(int amount) {
            if(weapon == null) {
                AttackEvent((int)(amount * strength));
            }
            else {
                amount = (int)amount + weapon.damage;
                AttackEvent((int)(amount * strength));
            }
            
        }

        public void AlterHealth(int amount) {
            Health += amount;
            if (Health > MaxHealth) {
                Health = MaxHealth;
            }
        }

        public void equipWeapon(Sword weaponToEquip) {
            if(weapon != weaponToEquip) {
                weapon = weaponToEquip;
            }
        }
    }
}