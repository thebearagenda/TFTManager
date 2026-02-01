using System;

namespace TFTManager
{
    public enum Role
    {
        AttackTank,
        AttackFighter,
        AttackReaper,
        AttackCaster,
        AttackCarry,
        MagicTank,
        MagicFighter,
        MagicReaper,
        MagicCaster,
        MagicCarry
    }

    public static class RolePower
    {
        public static double GetPower( Role role )
        {
            switch( role )
            {
                case Role.AttackTank:
                case Role.MagicTank:
                    return 0;
                case Role.AttackFighter:
                case Role.MagicFighter:
                    return 0.5;
                case Role.AttackReaper:
                case Role.MagicReaper:
                case Role.AttackCaster:
                case Role.MagicCaster:
                case Role.AttackCarry:
                case Role.MagicCarry:
                    return 1;
                default:
                    Console.Error.WriteLine($"Case not matched when determining role power.");
                    return 0;
            }
        }

        public static double GetResilience(Role role)
        {
            switch (role)
            {
                case Role.AttackTank:
                case Role.MagicTank:
                    return 1;
                case Role.AttackFighter:
                case Role.MagicFighter:
                    return 0.5;
                case Role.AttackReaper:
                case Role.MagicReaper:
                case Role.AttackCaster:
                case Role.MagicCaster:
                case Role.AttackCarry:
                case Role.MagicCarry:
                    return 0;
                default:
                    Console.Error.WriteLine($"Case not matched when determining role power.");
                    return 0;
            }
        }
    }
}
