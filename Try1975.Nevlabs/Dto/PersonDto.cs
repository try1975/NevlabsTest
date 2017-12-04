using System;
using System.Text.RegularExpressions;

namespace Try1975.Nevlabs.Dto
{
    public class PersonDto
    {
        private string _phone;
        private string _birthday;
        private string _email;
        private string _fullname;

        public string Fullname
        {
            get { return _fullname; }
            set { _fullname = string.IsNullOrEmpty(value) ? value : value.ToUpper(); }
        }

        public string Birthday
        {
            get { return _birthday; }
            set { _birthday = string.IsNullOrEmpty(value) ? value : value.ToUpper(); }
        }

        public string Email
        {
            get { return _email; }
            set { _email = string.IsNullOrEmpty(value) ? value : value.ToUpper(); }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = string.IsNullOrEmpty(value) ? value : Regex.Replace(value, "[^0-9.]", ""); }
        }

        public int Id { get; set; }

        public static PersonDto FromCsv(string csvLine, string[] csvSplitter)
        {
            var values = csvLine.Split(csvSplitter, StringSplitOptions.None);
            var contentDto = new PersonDto
            {
                Fullname = values[0].Replace("\"", ""),
                Birthday = values[1].Replace("\"", ""),
                Email = values[2].Replace("\"", ""),
                Phone = values[3].Replace("\"", "")
            };

            return contentDto;
        }

    }
}