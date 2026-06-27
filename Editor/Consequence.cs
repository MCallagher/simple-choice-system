using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleChoiceSystem
{
    public class Consequence
    {
        private readonly ConsequenceType _consequenceType;
        private readonly ConsequenceTime _consequenceTime;
        private readonly Dictionary<string, string> _parameters;

        public Consequence(
            ConsequenceType consequenceType,
            ConsequenceTime consequenceTime,
            Dictionary<string, string> parameters=null)
        {
            _consequenceType = consequenceType;
            _consequenceTime = consequenceTime;
            _parameters = parameters ?? new Dictionary<string, string>();
        }

        public ConsequenceType ConsequenceType => _consequenceType;

        public ConsequenceTime ConsequenceTime => _consequenceTime;

        public bool HasOption(string key)
        {
            return _parameters.ContainsKey(key);
        }

        public string GetOption(string key)
        {
            return _parameters[key];
        }

        public List<string> GetOptionKeys()
        {
            return _parameters.Keys.ToList();
        }
    }
}
