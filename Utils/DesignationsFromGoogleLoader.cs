using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medzoom.CDSS.DTO;

namespace TestInference.Utils
{
    public interface IDesignationsProvider
    {
        public string GetDesignation(Coding code, string name = "");
        public string GetDesignation(string code, string name = "");
    }

    public class DesignationsFromGoogleProvider : IDesignationsProvider
    {
        public string GetDesignation(string code, string name = "")
        {
            throw new NotImplementedException();
        }
        public string GetDesignation(Coding code, string name = "")
        {
            throw new NotImplementedException();
        }
    }
}
