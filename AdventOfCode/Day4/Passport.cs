using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day4
{
    public enum HeightType
    {
        Unknown = 0,
        Centimeters,
        Inches
    }
    public class Passport
    {
        public int BirthYear { get; set; }
        public int IssueYear { get; set; }
        public int ExpirationYear { get; set; }
        public int Height { get; set; }
        public HeightType HeightType { get; set; } = 0;
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportId { get; set; }
        public int CountryId { get; set; }
        public bool ValidIgnoreCid()
        {
            if (BirthYear == 0) return false;
            if (IssueYear == 0) return false;
            if (ExpirationYear == 0) return false;
            if (Height == 0) return false;
            if (string.IsNullOrWhiteSpace(HairColor)) return false;
            if (string.IsNullOrWhiteSpace(EyeColor)) return false;
            if (string.IsNullOrWhiteSpace(PassportId)) return false;
            return true;
        }
        public bool BetterValidation()
        {
            if (!ValidBYR()) return false;
            if (!ValidECL()) return false;
            if (!ValidEYR()) return false;
            if (!ValidHCL()) return false;
            if (!ValidHGT()) return false;
            if (!ValidIYR()) return false;
            if (!ValidPID()) return false;
            return true;
        }
        public Passport(string passportString)
        {
            SetBYR(passportString);
            SetIYR(passportString);
            SetEYR(passportString);
            SetHGT(passportString);
            SetHCL(passportString);
            SetECL(passportString);
            SetPID(passportString);
            SetCID(passportString);
        }

        private void SetCID(string passportString)
        {
            string pattern = @"cid:\d+";
            var match = Regex.Match(passportString, pattern);
            if (match.Success)
            {
                CountryId = int.Parse(Regex.Match(match.Value, @"\d+").Value);
            }
        }

        private void SetPID(string passportString)
        {
            string pattern = @"pid:#?\w+";
            var match = Regex.Match(passportString, pattern);
            if (match.Success)
            {
                PassportId = match.Value.Substring(4,match.Value.Length-4);
            }
        }

        private void SetECL(string passportString)
        {
            string pattern = @"ecl:#?[\d\w]+";
            var match = Regex.Match(passportString, pattern);
            if (match.Success)
            {
                EyeColor = match.Value.Substring(4, match.Value.Length - 4);
            }
        }

        private void SetHCL(string passportString)
        {
            string pattern = @"hcl:#?[\d\w]+";
            var match = Regex.Match(passportString, pattern);
            if (match.Success)
            {
                HairColor = match.Value.Substring(4,match.Value.Length-4);
            }
        }

        private void SetHGT(string passportString)
        {
            string pattern = @"hgt:\d+(in|cm)?";
            var match = Regex.Match(passportString, pattern);
            if (match.Success)
            {
                Height = int.Parse(Regex.Match(match.Value,@"\d+").Value);
                string type = Regex.Match(match.Value, @"(in|cm)").Value;
                switch (type)
                {
                    case "in":
                        HeightType = HeightType.Inches;
                        break;
                    case "cm":
                        HeightType = HeightType.Centimeters;
                        break;
                    default:
                        break;
                }
            }
        }

        private void SetEYR(string passportString)
        {
            string pattern = @"eyr:\d{4}";
            var match = Regex.Match(passportString, pattern);
            if (match.Success)
            {
                ExpirationYear = int.Parse(Regex.Match(match.Value, @"\d+").Value);
            }
        }

        private void SetIYR(string passportString)
        {
            string pattern = @"iyr:\d{4}";
            var match = Regex.Match(passportString, pattern);
            if (match.Success)
            {
                IssueYear = int.Parse(Regex.Match(match.Value, @"\d+").Value);
            }
        }

        private void SetBYR(string passportString)
        {
            string pattern = @"byr:\d{4}";
            var match = Regex.Match(passportString, pattern);
            if (match.Success)
            {
                BirthYear = int.Parse(Regex.Match(match.Value, @"\d+").Value);
            }
        }
        public bool ValidBYR() => BirthYear >= 1920 && BirthYear <= 2002;
        public bool ValidIYR() => IssueYear >= 2010 && IssueYear <= 2020;
        public bool ValidEYR() => ExpirationYear >= 2020 && ExpirationYear <= 2030;
        public bool ValidHGT()
        {
            switch (HeightType)
            {
                case HeightType.Unknown:
                    return false;
                case HeightType.Centimeters:
                    return Height >= 150 && Height <= 193;
                case HeightType.Inches:
                    return Height >= 59 && Height <= 76;
                default:
                    break;
            }
            return false;
        }
        public bool ValidHCL() => !string.IsNullOrWhiteSpace(HairColor) && Regex.Match(HairColor, @"\#[0-9a-f]{6}").Success;
        public bool ValidECL() => !string.IsNullOrWhiteSpace(EyeColor) && Regex.Match(EyeColor, @"\b(amb|blu|brn|gry|grn|hzl|oth)\b").Success;
        public bool ValidPID() => !string.IsNullOrWhiteSpace(PassportId) && Regex.Match(PassportId, @"^\d{9}$").Success;
    }

}
