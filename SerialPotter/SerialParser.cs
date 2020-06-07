
using CerealPotter.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CerealPotter
{
    class SerialParser
    {
        Regex reg;
        string expression;
        public SerialParser()
        {
            expression = Settings.Default.regex_pattern;
            reg = new Regex(expression, RegexOptions.IgnoreCase);
        }
        public Dictionary<string,double> ParsingMatch(string input)
        {
            Dictionary<string, double> matchesTable = new Dictionary<string, double>();
            MatchCollection matches = reg.Matches(input);
            foreach(Match match in matches)
            {
                string name = match.Groups[1].Value;
                double value = double.Parse(match.Groups[2].Value);
                matchesTable.Add(name, value);
            }
            return matchesTable;
        }
    }
}
