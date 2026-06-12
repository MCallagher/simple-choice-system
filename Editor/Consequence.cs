using System;
using System.Collections.Generic;

namespace SimpleChoiceSystem
{
    public class Consequence
    {
        private readonly string _description;
        private readonly ConsequenceType _consequenceType;
        private readonly ConsequenceTime _consequenceTime;
        private readonly Dictionary<string, object> _parameters;

        public Consequence(
            string description,
            ConsequenceType consequenceType,
            ConsequenceTime consequenceTime,
            Dictionary<string, object> parameters=null)
        {
            _description = description;
            _consequenceType = consequenceType;
            _consequenceTime = consequenceTime;
            _parameters = parameters ?? new Dictionary<string, object>();
        }

        public string Description => _description;

        public ConsequenceType ConsequenceType => _consequenceType;

        public ConsequenceTime ConsequenceTime => _consequenceTime;

        public bool HasOption(string key)
        {
            return _parameters.ContainsKey(key);
        }

        public T GetOption<T>(string key)
        {
            if (_parameters.TryGetValue(key, out var value))
            {
                return (T)value;
            }

            throw new KeyNotFoundException($"Key '{key}' not found in consequence parameters.");
        }

        public List<string> GetOptionKeys()
        {
            return new List<string>(_parameters.Keys);
        }
    }
}
