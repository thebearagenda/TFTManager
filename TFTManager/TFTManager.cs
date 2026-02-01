using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TFTManager
{
    public partial class TFTManager : Form
    {
        private const string s_unselected = "Unselected";
        private const string s_selected = "Selected";
        private const string s_contested = "Contested";

        private TraitImporter _traitImporter;
        private ChampionImporter _championImporter;
        private TraitCalculations _traitsCalculations;

        public ObservableCollection<Trait> SelectedTraits = new ObservableCollection<Trait>();
        public ObservableCollection<List<Trait>> PossibleTraits = new ObservableCollection<List<Trait>>();
        public ObservableCollection<Trait> PossibleBonusTraits = new ObservableCollection<Trait>();

        public Dictionary<Button, Label> Traits;

        public TFTManager()
        {
            _traitImporter = new TraitImporter();
            _traitImporter.ImportTraits();
            _championImporter = new ChampionImporter(_traitImporter);
            _championImporter.ImportChampions();
            _traitsCalculations = new TraitCalculations(_traitImporter, _championImporter);            

            InitializeComponent();
            ListTraits(_traitImporter);
            SelectedTraits.CollectionChanged += SelectedTraits_CollectionChanged;
        }

        private void ListTraits( TraitImporter traitImporter )
        {
            Traits = new Dictionary<Button, Label>();
            TableLayoutPanel originTable = new TableLayoutPanel() {  Dock = DockStyle.Fill, ColumnCount = 2, AutoSize = true };
            OriginPanel.Controls.Add(originTable);
            TableLayoutPanel classTable = new TableLayoutPanel() { Dock = DockStyle.Fill, ColumnCount = 2, AutoSize = true };
            ClassPanel.Controls.Add(classTable);

            bool origin = true;
            string previousTrait = string.Empty;

            foreach(Trait trait in traitImporter.Traits )
            {
                if(string.CompareOrdinal(previousTrait, trait.Name) > 0)
                {
                    origin = false;
                }
                previousTrait = trait.Name;

                Button button = new Button();
                button.Text = s_unselected;
                Label label = new Label();
                label.Text = trait.Name;
                label.TextAlign = ContentAlignment.MiddleLeft;

                Traits[button] = label;

                button.MouseUp += Button_Click;

                if(origin)
                {
                    originTable.Controls.Add(button);
                    originTable.Controls.Add(label);
                }
                else
                {
                    classTable.Controls.Add(button);
                    classTable.Controls.Add(label);
                }
            }
        }

        private void Button_Click(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;

            switch(e.Button)
            {
                case MouseButtons.Left:
                    ToggleSelected(button);
                    return;
                case MouseButtons.Right:
                    ToggleContested(button);
                    return;
                default:
                    return;
            }
        }

        private void ToggleSelected(Button button)
        {
            if (button.Text == s_selected)
            {
                SetUnselected(button);
                SelectedTraits.Remove(SelectedTraits.FirstOrDefault(x => x.Name == Traits[button].Text));
                return;
            }

            SetSelected(button);
        }

        private void ToggleContested(Button button)
        {
            if(button.Text == s_contested)
            {
                SetUnselected(button);
                return;
            }

            SetContested(button);
        }

        private void SetUnselected(Button button)
        {
            button.Text = s_unselected;
            Traits[button].Font = new Font(Traits[button].Font, FontStyle.Regular);
            SelectedTraits.Remove(SelectedTraits.FirstOrDefault(x => x.Name == Traits[button].Text));
        }

        private void SetSelected(Button button)
        {
            button.Text = s_selected;
            Traits[button].Font = new Font(Traits[button].Font, FontStyle.Bold);
            SelectedTraits.Add(_traitImporter.GetTrait(Traits[button].Text));
        }

        private void SetContested(Button button)
        {
            button.Text = s_contested;
            Traits[button].Font = new Font(Traits[button].Font, FontStyle.Strikeout);
            SelectedTraits.Remove(SelectedTraits.FirstOrDefault(x => x.Name == Traits[button].Text));
        }

        private void SelectedTraits_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if( SelectedTraits.Count > 3)
            {
                RemoveFirstSelection();
                return;
            }

            SelectedTraitsPanel.Controls.Clear();
            BonusPanel.Controls.Clear();

            for(int i = 0; i < SelectedTraits.Count; i++)
            {
                SelectedTraitsPanel.Controls.Add(new Label() { Text = SelectedTraits[i].Name, TextAlign = ContentAlignment.MiddleLeft, AutoSize = true });
                string intersections = string.Join(", ", _traitsCalculations.GetIntersectionNames(SelectedTraits[i].Name));
                SelectedTraitsPanel.Controls.Add(new Label() { Text = intersections, TextAlign = ContentAlignment.MiddleLeft, AutoSize = true });
                BonusPanel.Controls.Add(new Label() { Text = "• " + SelectedTraits[i].Bonus, TextAlign = ContentAlignment.MiddleLeft, AutoSize = true });
            }

            List<Trait> additionalTraits = _championImporter.FindAdditionalTraits(SelectedTraits.ToArray());
            PossibleAdditionalTraitsPanel.Controls.Clear();
            for(int i = 0; i < additionalTraits.Count;i++)
            {
                PossibleAdditionalTraitsPanel.Controls.Add(new Label() { Text = additionalTraits[i].Name, TextAlign = ContentAlignment.MiddleLeft, AutoSize = true });
                BonusPanel.Controls.Add(new Label() { Text = "• " + additionalTraits[i].Bonus, TextAlign = ContentAlignment.MiddleLeft, AutoSize = true  });
            }

            double resilience = SelectedTraits.Count > 0 ? SelectedTraits.Sum(x => _traitsCalculations.TraitResilience[x]) : 0;
            double power = SelectedTraits.Count > 0 ? SelectedTraits.Sum(x => _traitsCalculations.TraitPower[x]) : 0;
            int synergy = _traitsCalculations.CountAllIntersections(SelectedTraits.ToList()) + additionalTraits.Count;
            int attack = SelectedTraits.Count > 0 ? SelectedTraits.Sum(x => _traitsCalculations.TraitAttackPower[x]) : 0;
            int magic = SelectedTraits.Count > 0 ? SelectedTraits.Sum(x => _traitsCalculations.TraitMagicPower[x]) : 0;

            ResilienceLevel.Text = resilience.ToString();
            ResilienceBar.Value = power == 0 ? 100 : (int)Math.Min(resilience / power * 100, 100);

            PowerLevel.Text = power.ToString();
            PowerBar.Value = resilience == 0 ? 100 : (int)Math.Min(power / resilience * 100, 100);

            SynergyLevel.Text = synergy.ToString();
            SynergyLevel.BackColor = _traitsCalculations.GetSynergyColorByValue(synergy);

            AttackLabel.Text = attack.ToString();
            MagicLabel.Text = magic.ToString();
        }

        private void RemoveFirstSelection()
        {
            Trait trait = SelectedTraits[0];
            Button button = Traits.FirstOrDefault(x => x.Value.Text == trait.Name).Key;
            button.Text = "Unselected";
            Traits[button].Font = new Font(Traits[button].Font, FontStyle.Regular);
            SelectedTraits.RemoveAt(0);
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            foreach(Button button in Traits.Keys)
            {
                SetUnselected(button);
            }
        }

        private void ResetSelected_Click(object sender, EventArgs e)
        {
            List<Button> buttons = new List<Button>();

            foreach (Button button in Traits.Keys)
            {
                if(button.Text == s_selected)
                {
                    buttons.Add(button);
                }
            }

            buttons.ForEach(button => SetUnselected(button));
        }

        private void ResetContested_Click(object sender, EventArgs e)
        {
            List<Button> buttons = new List<Button>();

            foreach (Button button in Traits.Keys)
            {
                if (button.Text == s_contested)
                {
                    buttons.Add(button);
                }
            }

            buttons.ForEach(button => SetUnselected(button));
        }
    }
}
