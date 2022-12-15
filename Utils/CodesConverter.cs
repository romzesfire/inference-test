using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medzoom.CDSS.Common.CodeSystemReplacements;
using Medzoom.CDSS.DTO;

namespace TestInference.Utils
{
    public interface ICodesConverter
    {
        public Coding ShortToCoding(string code);
        public string CodingToShort(Coding code);
    }

    public class CodesConverter : ICodesConverter
    {
        private IReadOnlyDictionary<string, string> _systems;
        public CodesConverter()
        {
            _systems = CodeSystems.StandardReplacements;
        }
        public Coding ShortToCoding(string code)
        {
            foreach (var system in _systems)
                if (code.StartsWith(system.Key))
                    return new Coding(system.Value, code.Replace(system.Key, ""));

            throw new Exception($"Codesystem of {code} is not found");
        }
        public string CodingToShort(Coding code)
        {
            foreach (var system in _systems)
                if(code.CodeSystemUrl == system.Value)
                    return system.Key+code.Code;

            throw new Exception($"Codesystem of {code} is not found");
        }
    }

}
