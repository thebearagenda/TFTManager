using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTManager
{
    public class TraitCalculations
    {
        private TraitImporter _traitImporter;
        private ChampionImporter _championImporter;

        private const double _maxValue = 12;
        private const double _maxSynergyValue = 6;

        private Color _minColor = Color.Red;
        private Color _maxColor = Color.FromArgb(255, 0, 176, 80);

        public Dictionary<Trait, List<Hero>> HeroesPerTrait { get; } = new Dictionary<Trait, List<Hero>>();
        public Dictionary<Trait, List<Trait>> Intersections { get; } = new Dictionary<Trait, List<Trait>>();
        public Dictionary<Trait,double> TraitResilience { get; } = new Dictionary<Trait, double>();
        public Dictionary<Trait,double> TraitPower { get; } = new Dictionary<Trait, double>();
        public Dictionary<Trait, int> TraitAttackPower { get; } = new Dictionary<Trait, int>();
        public Dictionary<Trait, int> TraitMagicPower { get; } = new Dictionary<Trait, int>();

        public TraitCalculations( TraitImporter traitImporter, ChampionImporter championImporter )
        {
            _traitImporter = traitImporter;
            _championImporter = championImporter;
            Calculate();
        }

        public Color GetColorByValue( double value )
        {
            if( value <= 0 )
            {
                return _minColor;
            }    

            if( value >= _maxValue )
            {
                return _maxColor;
            }

            double red = _minColor.R + (_maxColor.R - _minColor.R) * (value / _maxValue);
            double green = _minColor.G + (_maxColor.G - _minColor.G) * (value / _maxValue);
            double blue = _minColor.B + (_maxColor.B - _minColor.B) * (value / _maxValue);

            red = Math.Min(red, 255);
            green = Math.Min(green, 255);
            blue = Math.Min(blue, 255);

            return Color.FromArgb(255, (int)red, (int)green, (int)blue);
        }

        public Color GetSynergyColorByValue( double value )
        {
            if (value <= 0)
            {
                return _minColor;
            }

            if (value >= _maxSynergyValue)
            {
                return _maxColor;
            }

            double red = _minColor.R + (_maxColor.R - _minColor.R) * (value / _maxSynergyValue);
            double green = _minColor.G + (_maxColor.G - _minColor.G) * (value / _maxSynergyValue);
            double blue = _minColor.B + (_maxColor.B - _minColor.B) * (value / _maxSynergyValue);

            red = Math.Min(red, 255);
            green = Math.Min(green, 255);
            blue = Math.Min(blue, 255);

            return Color.FromArgb(255, (int)red, (int)green, (int)blue);
        }

        public int CountAllIntersections( List<Trait> traits )
        {
            int sum = 0;
            for( int i = 0; i < traits.Count - 1; i++ )
            {
                sum += CountIntersections( traits[i], traits[i + 1] );
            }
            return sum;
        }

        private int CountIntersections( Trait x, Trait y )
        {
            return _championImporter.GetHeroesByTraits(x, y)?.Count ?? 0;
        }

        public List<string> GetIntersectionNames(string traitName)
        {
            return GetIntersections(traitName).Select(t => t.Name).ToList();
        }

        public List<Trait> GetIntersections(string traitName)
        {
            return GetIntersections(_traitImporter.GetTrait(traitName));
        }

        public List<Trait> GetIntersections(Trait trait)
        {
            return Intersections[trait];
        }

        private void Calculate()
        {
            CalculateHeroesPerTrait();
            CalculateTraitResilience();
            CalculateTraitPower();
            CalculateIntersections();
            CalculateAttackPower();
            CalculateMagicPower();
        }

        private void CalculateHeroesPerTrait()
        {
            foreach (Trait trait in _traitImporter.Traits)
            {
                HeroesPerTrait[trait] = new List<Hero>();

                foreach (Hero hero in _championImporter.Heroes)
                {
                    List<string> traitNames = hero.GetTraitNames();
                    if (!traitNames.Contains(trait.Name)) continue;
                    HeroesPerTrait[trait].Add(hero);
                }
            }
        }

        private void CalculateTraitResilience()
        {
            foreach( Trait trait in HeroesPerTrait.Keys )
            {
                double resilience = HeroesPerTrait[trait].Sum(x => RolePower.GetResilience(x.Role));
                TraitResilience[trait] = resilience;
            }
        }

        private void CalculateTraitPower()
        {
            foreach (Trait trait in HeroesPerTrait.Keys)
            {
                double power = HeroesPerTrait[trait].Sum(x => RolePower.GetPower(x.Role));
                TraitPower[trait] = power;
            }
        }

        private void CalculateAttackPower()
        {
            foreach (Trait trait in HeroesPerTrait.Keys)
            {
                int power = HeroesPerTrait[trait].Count(x => x.Role.ToString().Contains("Attack"));
                TraitAttackPower[trait] = power;
            }
        }

        private void CalculateMagicPower()
        {
            foreach (Trait trait in HeroesPerTrait.Keys)
            {
                int power = HeroesPerTrait[trait].Count(x => x.Role.ToString().Contains("Magic"));
                TraitMagicPower[trait] = power;
            }
        }

        private void CalculateIntersections()
        {
            foreach( Trait trait in _traitImporter.Traits )
            {
                List<Trait> intersections = new List<Trait>();

                foreach( Hero hero in HeroesPerTrait[trait] )
                {
                    List<string> traitNames = hero.GetTraitNames();
                    intersections.AddRange(traitNames.Select( t => _traitImporter.GetTrait( t ) ) );
                }

                HashSet<Trait> uniqueIntersections = intersections.ToHashSet();
                uniqueIntersections.Remove(trait);
                Intersections[trait] = uniqueIntersections.ToList();
            }
        }
    }
}
