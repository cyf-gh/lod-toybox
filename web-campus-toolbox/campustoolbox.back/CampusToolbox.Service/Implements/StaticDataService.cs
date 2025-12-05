using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CampusToolbox.Service.Implements {
    public class StaticDataService : IStaticDataService {
        private string provinces;
        private string areas;

        private string StaticDataJsonDirectory = Path.Combine( Environment.CurrentDirectory, "_StaticData" );
        private string colleges;

        private string grades;

        private string ReadAllTextFromFile( string fileName ) {
            return File.ReadAllText( Path.Combine( StaticDataJsonDirectory, fileName ) );
        }

        public StaticDataService() {
            provinces = ReadAllTextFromFile( "cn-provinces.json" );
            areas = ReadAllTextFromFile( "cn-areas.json" );
            colleges = ReadAllTextFromFile( "cn-colleges.json" );
            grades = ReadAllTextFromFile( "grades.json" );
        }

        public string GetProvinces() {
            return provinces;
        }

        public string GetAreas() {
            return areas;
        }

        public string GetColleges() {
            return colleges;
        }

        public string GetGrades() {
            return grades;
        }
    }
}
