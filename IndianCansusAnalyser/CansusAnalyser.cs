using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
namespace IndianCansusAnalyser
{
    public class CensusAnalyser
    {
        public Dictionary<string, IndianStateCansusAnalyser> data;
        public Dictionary<string, IndianStateCansusAnalyser> CensusData(string csvFilePath, string dataHeaders)
        {
            data = new Dictionary<string, IndianStateCansusAnalyser>();

            if (!File.Exists(csvFilePath))
            {
                throw new CensusException(CensusException.ExceptionType.FILE_NOT_EXIST, "File does not exist");
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusException(CensusException.ExceptionType.IMPROPER_EXTENSION, "Improper extension");
            }

            string[] censusData = File.ReadAllLines(csvFilePath);
            if (censusData[0] != dataHeaders)
            {
                throw new CensusException(CensusException.ExceptionType.INCORRECT_HEADER, "Incorrect Header");
            }

            foreach (string row in censusData.Skip(1))
            {
                if (row.Contains("-"))
                {
                    throw new CensusException(CensusException.ExceptionType.DELIMITER_NOT_FOUND, "Delimiter is not found");
                }
                string[] column = row.Split(',');
                data.Add(column[0], new IndianStateCansusAnalyser(column[0], column[1], column[2], column[3]));
            }
            return data;
        }
        public Dictionary<string, IndianStateCodeAnalyser> dataMap;
        public Dictionary<string, IndianStateCodeAnalyser> IndianStateCode(string csvPath, string Headers)
        {
            dataMap = new Dictionary<string, IndianStateCodeAnalyser>();
            if (!File.Exists(csvPath))
            {
                throw new CensusException(CensusException.ExceptionType.FILE_NOT_EXIST, "File does not exist");
            }
            if (Path.GetExtension(csvPath) != ".csv")
            {
                throw new CensusException(CensusException.ExceptionType.IMPROPER_EXTENSION, "Improper extension");
            }
            string[] censusData = File.ReadAllLines(csvPath);
            if (censusData[0] != Headers)
            {
                throw new CensusException(CensusException.ExceptionType.INCORRECT_HEADER, "Incorrect Header");
            }
            foreach (string row in censusData.Skip(1))
            {
                if (row.Contains("-"))
                {
                    throw new CensusException(CensusException.ExceptionType.DELIMITER_NOT_FOUND, "Delimiter is not found");
                }
                string[] column = row.Split(',');
                dataMap.Add(column[0], new IndianStateCodeAnalyser(column[0], column[1], column[2], column[3]));
            }
            return dataMap;
        }
    }
}
