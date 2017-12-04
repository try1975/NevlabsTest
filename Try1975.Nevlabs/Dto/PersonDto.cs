using System;
using System.Text.RegularExpressions;

namespace Try1975.Nevlabs.Dto
{
    public class PersonDto
    {
        public string Fullname { get; set; }

        public string Birthday { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int Id { get; set; }

        public static PersonDto FromCsv(string csvLine, string[] csvSplitter)
        {
            var values = csvLine.Split(csvSplitter, StringSplitOptions.None);
            var contentDto = new PersonDto
            {
                Fullname = string.IsNullOrEmpty(values[0]) ? values[0] : values[0].Replace("\"", "").ToUpper(),
                Birthday = string.IsNullOrEmpty(values[1]) ? values[1] : values[1].Replace("\"", "").Replace("-", ".").Replace("/", "."),
                Email = string.IsNullOrEmpty(values[2]) ? values[2] : values[2].Replace("\"", "").ToUpper(),
                Phone = string.IsNullOrEmpty(values[3]) ? values[3] : Regex.Replace(values[3].Replace("\"", ""), "[^0-9.]", "")
            };

            return contentDto;
        }

    }
}