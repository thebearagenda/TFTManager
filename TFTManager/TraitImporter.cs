using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TFTManager
{
    public class TraitImporter
    {
        public List<Trait> Traits { get; private set; }

        public void ImportTraits()
        {
            string[] lines = Properties.Resources.Traits.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);


            Traits = new List<Trait>();

            for (int i = 0; i < lines.Length; i++)
            {
                if (!AddTrait(lines[i])) Console.Error.WriteLine($"Cannot parse trait on line {i + 1}, skipping trait.");
            }
        }

        private bool AddTrait(string line)
        {
            Trait trait = new Trait();

            try
            {
                string[] attributes = line.Split(new char[] { '\t' });

                if( attributes.Length < 3 )
                {
                    return false;
                }

                trait.Name = attributes[0].Trim();
                trait.Bonus = attributes[1].Trim();

                if( !int.TryParse( attributes[2], out int min) )
                {
                    return false;
                }

                trait.MinimumRequired = min;

                Traits.Add(trait);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool IsItATrait( string trait )
        {
            return Traits.Any( x => x.Name == trait );
        }

        public Trait GetTrait( string name )
        {
            return Traits.First( x => x.Name == name );
        }
    }
}
