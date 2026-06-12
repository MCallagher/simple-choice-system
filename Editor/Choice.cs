using System.Collections.Generic;

namespace SimpleChoiceSystem
{
    public class Choice
    {
        private readonly string _context;
        private readonly List<Option> _options;
        private int _decision;

        public Choice(string context, List<Option> options)
        {
            _context = context;
            _options = options ?? new List<Option>();
            _decision = -1;
        }

        public string Context => _context;

        public List<Option> Options => _options;

        public Option Decision => _decision >= 0 ? _options[_decision] : null;

        public List<string> GetOptionDescriptions()
        {
            List<string> descriptions = new List<string>();
            foreach (var option in _options)
            {
                descriptions.Add(option.Description);
            }
            return descriptions;
        }

        public Option Choose(int index)
        {
            if (_decision >= 0)
            {
                throw new System.InvalidOperationException("A decision has already been made for this choice.");
            }

            if (index >= 0 && index < _options.Count)
            {
                _decision = index;
                return _options[index];
            }
            throw new System.IndexOutOfRangeException($"Index {index} is out of range for options list.");
        }
    }
}
