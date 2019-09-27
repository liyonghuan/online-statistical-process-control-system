using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace onlineSPC
{
    class RegexClass
    {
        public bool IsFloat(string input)
        {
            string pattern = @"^([+-]?)((([1-9]{1})([0-9]{1,}))|([0-9]{1}))(([.]{1})([0-9]{1,}))?$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }

        public bool IsNumAndEnCh(string input)
        {
            string pattern = @"^[A-Za-z0-9]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }
        public bool IsNum(string input)
        {
            string pattern = @"^[0-9]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }

        public bool IsPhoneNum(string input)
        {
            string pattern = @"(\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }

        public bool IsIdCard(string input)
        {
            string pattern = @"^(^\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }
    }
}
