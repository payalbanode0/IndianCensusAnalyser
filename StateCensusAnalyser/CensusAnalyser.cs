using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndianStateCensusAnalysis.POCO;
using Newtonsoft.Json;

namespace IndianStateCensusAnalysis
{
    public class CensusAnalyser
    {
        public enum Country
        {
            INDIA, US, BRAZIL
        }

        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            dataMap = new CSVAdaptorFactory().LoadCSVData(country, csvFilePath, dataHeaders);
            return dataMap;
        }

    }
}