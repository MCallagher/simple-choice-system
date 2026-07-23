using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleChoiceSystem
{
    public class Consequence
    {
        private readonly ConsequenceType _consequenceType;
        private readonly Dictionary<string, string> _parameters;

        public Consequence(
            ConsequenceType consequenceType,
            Dictionary<string, string> parameters=null)
        {
            _consequenceType = consequenceType;
            _parameters = parameters ?? new Dictionary<string, string>();
        }

        public ConsequenceType ConsequenceType => _consequenceType;

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

        public class OptionKey
        {
            public static readonly string Damage = "damage";
            public static readonly string Heal = "heal";
            public static readonly string Karma = "karma";
            public static readonly string Room = "room";
        }
    }
}
