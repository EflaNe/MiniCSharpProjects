using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgArenaConsole.Domain
{
    public class Character
    {
        private string _name;
        private int _level;
        private int _attack;
        private int _defense;

        private int _maxHealth;
        private int _currentHealth;

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name boş olamaz.");
                _name = value.Trim();
            }
        }
        
        public int Level
        {
            get => _level;
            private set
            {
                _level = Mathx.Clamp(value, 1, 99);
            }
        }
        public int Attack
        {
            get => _attack;
            private set
            {
                _attack = Mathx.Clamp(value, 0, 999);
            }
        }

        public int Defense
        {
            get => _defense;
            private set
            {
                _defense = Mathx.Clamp(value, 0, 999);
            }
        }

        public int MaxHealth
        {
            get => _maxHealth;
            private set
            {
                _maxHealth = Mathx.Clamp(value, 1, 9999);
                _currentHealth = Mathx.Clamp(_currentHealth, 0, _maxHealth);
            }
        }

        public int CurrentHealth
        {
            get => _currentHealth;
            private set
            {
                _currentHealth = Mathx.Clamp(value, 0, MaxHealth);
            }
        }

        public bool IsDead => CurrentHealth <= 0;

        public Character(string name, int level, int attack, int defense, int maxHealth)
        {
            Name = name;
            Level = level;
            Attack = attack;
            Defense = defense;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth; 
        }

        public int CalculateDamageAgainst(Character target)
        {
            int raw = (Attack + Level * 2) - target.Defense;

            return Math.Max(1, raw);
        }

        public int AttackTarget(Character target)
        {
            if (IsDead) return 0;

            int dmg = CalculateDamageAgainst(target);
            target.TakeDamage(dmg);
            return dmg;
        }

        public void TakeDamage(int amount)
        {
            if (amount < 0) amount = 0;
            CurrentHealth -= amount;
        }

        public int Heal(int amount)
        {
            if (amount <= 0) return 0;
            int before = CurrentHealth;
            CurrentHealth += amount; 
            return CurrentHealth - before;
        }

        public override string ToString()
        {
            return $"{Name} (Lv{Level}) ATK:{Attack} DEF:{Defense} HP:{CurrentHealth}/{MaxHealth}";
        }
    }
}
