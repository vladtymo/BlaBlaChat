﻿using Client.Models.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Client
{
    public class MailValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([A-Z-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            
           
            return!Regex.IsMatch((value ?? "").ToString(), pattern)
                ? new ValidationResult(false, "")
                : ValidationResult.ValidResult;
            
        }
    }
    public class ValidationRuleNameSurname : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            return string.IsNullOrWhiteSpace((value ?? "").ToString())
                ? new ValidationResult(false,"")
                : ValidationResult.ValidResult;
        }
    }
    public class ValidationRuleNickName : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty(value?.ToString()))
            {
                return new ValidationResult(false, "");
            }
            return value.ToString()!="hello" /*UserProfileService.IsExistNicknameAsync((value??"").ToString()).Result*/
                ? new ValidationResult(false, "This nickname is already in use ")
                : ValidationResult.ValidResult;
        }
    }
    public class DateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime time;
            if (!DateTime.TryParse((value ?? "").ToString(),
                CultureInfo.CurrentCulture,
                DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces,
                out time)) return new ValidationResult(false, "");

            return time.Date.ToString() == " "
                ? new ValidationResult(false, "")
                : ValidationResult.ValidResult;
        }
    }
}
