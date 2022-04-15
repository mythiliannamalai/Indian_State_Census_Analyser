using NUnit.Framework;
using System;
using IndianCansusAnalyser;
namespace IndianCansusTesting
{
    public class Tests
    {
        string Path= @"C:\Users\user\source\repos\ConsoleApp2\CSVFile\";
        string validStateCensusFileState = "IndiaStateCensusData.csv";
        string invalidExtensionFileState = "IndiaStateCode.pdf";
        string invalidDelimiterFileState = "DelimiterIndiaStateCensusData.csv";
        string invalidHeaderState = "WrongIndiaStateCensusData.csv";
        CensusAnalyser censusAnalyser;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
        }
        //TC-1.1
        [Test]
        public void Given_CSVFile_TestRecordAreSame()
        {
            censusAnalyser.data = censusAnalyser.CensusData(Path + validStateCensusFileState, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(29, censusAnalyser.data.Count);
        }
        //TC-1.2
        [Test]
        public void Given_IncorrectCSVFileName_ReturnCustomException()
        {
            CensusException exc = Assert.Throws<CensusException>(() => censusAnalyser.CensusData(Path + validStateCensusFileState + "Txt", "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusException.ExceptionType.FILE_NOT_EXIST, exc.type);
        }
        //TC-1.3
        [Test]
        public void Given_IncorrectFileType_ReturnCustomException()
        {
            CensusException exc = Assert.Throws<CensusException>(() => censusAnalyser.CensusData(Path + invalidExtensionFileState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusException.ExceptionType.IMPROPER_EXTENSION, exc.type);
        }
        //TC-1.4
        [Test]
        public void Given_IncorrectDelimiter_ReturnCustomException()
        {
            CensusException exc = Assert.Throws<CensusException>(() => censusAnalyser.CensusData(Path + invalidDelimiterFileState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusException.ExceptionType.DELIMITER_NOT_FOUND, exc.type);
        }
        //TC-1.5
        [Test]
        public void Given_IncorrectHeader_ReturnCustomException()
        {
            CensusException exc = Assert.Throws<CensusException>(() => censusAnalyser.CensusData(Path + invalidHeaderState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusException.ExceptionType.INCORRECT_HEADER, exc.type);
        }
    }
}