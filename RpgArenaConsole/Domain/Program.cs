using RpgArenaConsole.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RpgArenaConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var warrior = new Character(name: "Warrior", level: 5, attack: 18, defense: 8, maxHealth: 90);
            var rogue = new Character(name: "Rogue", level: 6, attack: 16, defense: 6, maxHealth: 75);

            Console.WriteLine("Pre-warm: Rogue heal yourself for 10 .");
            int healed = rogue.Heal(10);
            Console.WriteLine($"Rogue heal: +{healed} HP → {rogue.CurrentHealth}/{rogue.MaxHealth}\n");

            Battle.TurnBased(warrior, rogue);


            Console.WriteLine("\nSon durumlar:");
            Console.WriteLine(warrior);
            Console.WriteLine(rogue);
        }
    }
    public static class Battle
    {
        public static void TurnBased(Character a, Character b, int delayMs = 500)
        {
            Console.WriteLine("=== BATTLE START ===");
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine();

            Character attacker = a;
            Character defender = b;

            while (!a.IsDead && !b.IsDead)
            {
                int dmg = attacker.AttackTarget(defender);
                Console.WriteLine($"{attacker.Name} -> {defender.Name} for {dmg} dmg | {defender.Name} HP: {defender.CurrentHealth}/{defender.MaxHealth}");

                if (defender.IsDead)
                {
                    Console.WriteLine($"\n{defender.Name} lose! Win: {attacker.Name} 🎉");
                    break;
                }

                // sırayı değiştir
                (attacker, defender) = (defender, attacker);

                Thread.Sleep(delayMs); 
            }

            Console.WriteLine("\n=== BATTLE END ===");
        }
    }
}
