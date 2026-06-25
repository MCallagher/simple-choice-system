using System.Collections.Generic;

namespace SimpleChoiceSystem
{
    public class Option
    {
        private readonly string _description;
        private readonly string _effect;
        private readonly List<Consequence> _consequences;

        public Option(string description, string effect, List<Consequence> consequences)
        {
            _description = description;
            _effect = effect;
            _consequences = consequences ?? new List<Consequence>();
        }

        public string Description => _description;

        public string Effect => _effect;

        public List<Consequence> Consequences => _consequences;
    }
}
