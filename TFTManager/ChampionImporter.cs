using System;
using System.Collections.Generic;
using System.Linq;

namespace TFTManager
{
    public class ChampionImporter
    {
        private TraitImporter _traitImporter;
        public List<Hero> Heroes { get; private set; }

        public ChampionImporter( TraitImporter traitImporter )
        {
            _traitImporter = traitImporter;
        }

        public List<Hero> GetHeroesByTraits(params Trait[] traits )
        {
            Dictionary<Trait, List<Hero>> heroesByTrait = new Dictionary<Trait, List<Hero>>();

            foreach ( Trait trait in traits )
            {
                heroesByTrait[trait] = GetHeroesByTrait(trait);
            }

            return heroesByTrait[traits[0]].Where( h => heroesByTrait.Values.All( v => v.Contains( h ) ) ).ToList();
        }

        public List<Hero> GetHeroesByTrait( Trait trait )
        {
            return Heroes.Where(x => x.GetTraitNames().Contains(trait.Name)).ToList();
        }

        public List<Trait> FindAdditionalTraits(params Trait[] traits)
        {
            List<Hero> heroes = new List<Hero>();

            foreach (Trait trait in traits)
            {
                heroes.AddRange(GetHeroesByTrait(trait));
            }

            HashSet<Hero> uniqueHeroes = heroes.ToHashSet();
            return FindActiveTraits(uniqueHeroes.ToList()).Except(traits).ToList();
        }

        public List<Trait> FindActiveTraits(List<Hero> heroes)
        {
            Dictionary<Trait, List<Hero>> heroesByTrait = new Dictionary<Trait, List<Hero>>();

            foreach(Hero hero in heroes)
            {
                List<Trait> traits = hero.GetTraitNames().Select( n => _traitImporter.GetTrait(n)).ToList();

                foreach(Trait trait in traits)
                {
                    if( heroesByTrait.Keys.Contains(trait) )
                    {
                        continue;
                    }

                    List<Hero> list = GetHeroesByTrait(trait);
                    heroesByTrait[trait] = heroes.Where( h => list.Contains(h)).ToList();
                }
            }

            return heroesByTrait.Where( x => x.Value.Count() >= x.Key.MinimumRequired ).Select( y => y.Key).ToList();
        }

        public void ImportChampions()
        {
            string[] lines = Properties.Resources.Champions.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            Heroes = new List<Hero>();

            for(int i = 0; i < lines.Length; i++)
            {
                if( !AddChampion(lines[i]) ) Console.Error.WriteLine($"Cannot parse hero on line {i+1}, skipping hero.");
            }
        }

        private bool AddChampion( string line )
        {
            Hero hero = new Hero();

            try
            {
                string[] attributes = line.Split(new char[] { '\t' });

                if (attributes.Length < 4)
                {
                    Console.Error.WriteLine("There is not a enough attributes.");
                }

                hero.Name = attributes[0].Trim();

                if (!Enum.TryParse(attributes[1].Replace(" ", string.Empty), true, out Role roleEnum))
                {
                    Console.Error.WriteLine($"{attributes[1]} is not a valid role.");
                    return false;
                }

                hero.Role = roleEnum;

                if(!_traitImporter.IsItATrait(attributes[2].Trim()))
                {
                    Console.Error.WriteLine($"{attributes[2]} is not a valid trait.");
                    return false;
                }

                hero.Origin = attributes[2].Trim();

                if (!_traitImporter.IsItATrait(attributes[3].Trim()))
                {
                    Console.Error.WriteLine($"{attributes[3]} is not a valid trait.");
                    return false;
                }

                hero.Class1 = attributes[3].Trim();

                if (attributes.Length > 4)
                {
                    if (!_traitImporter.IsItATrait(attributes[4].Trim()))
                    {
                        Console.Error.WriteLine($"{attributes[4]} is not a valid trait.");
                        return false;
                    }

                    hero.Class2 = attributes[4].Trim();

                }

                Heroes.Add(hero);
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine($"{ex.GetType()} found.");
                return false;
            }
            
            return true;
        }
    }
}
