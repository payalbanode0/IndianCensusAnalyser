using NUnit.Framework;
using IndianStateCensusAnalysis.POCO;
using IndianStateCensusAnalysis;
using System.Collections.Generic;
using Newtonsoft.Json;
using static IndianStateCensusAnalysis.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityInSqKm";
        static string indianStateCodeHeaders = "SrNo,StateName,TIN,StateCode";
        static string indianStateCensusFilePath = @"D:\.net\Day 29 Indian States\IndianStateCensusAnalysis\CensusAnalyserTest\CSVFiles\IndianStateCensusData.csv";
        static string wrongHeaderIndianCensusDataFilePath = @"D:\.net\Day 29 Indian States\IndianStateCensusAnalysis\CensusAnalyserTest\CSVFiles\wrongIndianCensusData.csv";
        static string delimiterIndianCensusFilePath = @"D:\.net\Day 29 Indian States\IndianStateCensusAnalysis\CensusAnalyserTest\CSVFiles\DelimiterIndianStateCensusData.csv";
        static string wrongIndianStateCensusFilePath= @"D:\.net\Day 29 Indian States\IndianStateCensusAnalysis\CensusAnalyserTest\CSVFiles\IndianData.csv";
        static string wrongIndianStateCensusFileType= @"D:\.net\Day 29 Indian States\IndianStateCensusAnalysis\CensusAnalyserTest\CSVFiles\IndianStateCensusData.txt";
        static string indianStateCodeFilePath= @"D:\.net\Day 29 Indian States\IndianStateCensusAnalysis\CensusAnalyserTest\CSVFiles\IndianStateCode.csv";
        static string wrongIndianStateCodeFileType= @"D:\.net\Day 29 Indian States\IndianStateCensusAnalysis\CensusAnalyserTest\CSVFiles\IndianStateCode.txt";
        static string delimiterIndianStateCodeFilePath= @"D:\.net\Day 29 Indian States\IndianStateCensusAnalysis\CensusAnalyserTest\CSVFiles\DelimiterIndianStateCode.csv";
        static string wrongHeaderStateCodeFilePath= @"D:\.net\Day 29 Indian States\IndianStateCensusAnalysis\CensusAnalyserTest\CSVFiles\wrongIndianStateCode.csv";

        IndianStateCensusAnalysis.CensusAnalyser censusAnalyser;
        Dictionary<string ,CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStateCensusAnalysis.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();

        }
        //1.1 
        [Test]
        public void GivenIndianStateCensusDataFile_ReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(32, stateRecord.Count);
        }
        //1.2 
        [Test]
        public void GivenWrongIndianCensusDataFile_ReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }
        //1.3 
        [Test]
        public void GivenWrongIndianCensusDataFileType_ReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);

        }
        //1.4 
        [Test]
        public void GivenIndianCensusDataFile_WhenDelimiterNotProper_ReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }
        //1.5 
        [Test]
        public void GivenIndianCensusDataFileButWrongHeader_ReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusDataFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }

    }
}