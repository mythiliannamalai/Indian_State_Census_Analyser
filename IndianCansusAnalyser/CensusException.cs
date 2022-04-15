using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
namespace IndianCansusAnalyser
{
    public class CensusException : Exception
    {
        public ExceptionType type;
        public enum ExceptionType
        {
            FILE_NOT_EXIST,
            IMPROPER_EXTENSION,
            DELIMITER_NOT_FOUND,
            INCORRECT_HEADER
        }        
        public CensusException(ExceptionType type, string name) : base(name)
        {
            this.type = type;
        }
    }
    
}
