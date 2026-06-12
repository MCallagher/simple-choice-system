using System.Collections.Generic;

namespace SimpleChoiceSystem
{
    public class Option
    {
        private readonly string _description;
        private readonly List<Consequence> _consequences;

        public Option(string description, List<Consequence> consequences)
        {
            _description = description;
            _consequences = consequences ?? new List<Consequence>();
        }

        public string Description => _description;

        public List<Consequence> Consequences => _consequences;
    }
}
