using AdventOfCode;
using AdventOfCode.Day4;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfTests
{
    public class Day4Test
    {
        [Theory]
        [InlineData("ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm")]
        public void PartTwoTest(string passportString)
        {
            var passport = new Passport(passportString);
            Assert.Equal(1937, passport.BirthYear);
            Assert.Equal(2017, passport.IssueYear);
            Assert.Equal(2020, passport.ExpirationYear);
            Assert.Equal(183, passport.Height);
            Assert.Equal(HeightType.Centimeters, passport.HeightType);
            Assert.Equal("#fffffd", passport.HairColor);
            Assert.Equal("gry", passport.EyeColor);
            Assert.Equal("860033327", passport.PassportId);
            Assert.Equal(147, passport.CountryId);
        }
        [Theory]
        [InlineData("ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm", true)]
        [InlineData("iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884 hcl:#cfa07d byr:1929", false)]
        [InlineData("hcl:#ae17e1 iyr:2013 eyr:2024 ecl:brn pid:760753108 byr:1931 hgt:179cm", true)]
        [InlineData("hcl:#cfa07d eyr:2025 pid:166559648 iyr:2011 ecl:brn hgt:59in", false)]
        [InlineData("byr:2024 iyr:2016 eyr:2034 ecl:zzz pid:985592671 hcl:033b48 hgt:181 cid:166", true)]
        [InlineData("hgt:66cm pid:152cm hcl:cfb18a eyr:1947 byr:2020 ecl:zzz iyr:2029", true)]
        [InlineData("ecl:gry hcl:#888785 eyr:2023 cid:63 iyr:2019 hgt:177cm pid:656793259", false)]
        [InlineData("pid:#5e832a ecl:dne hcl:#7d3b0c byr:2018 eyr:1928 hgt:61cm iyr:1936 cid:241", true)]
        [InlineData("hcl:#888785 ecl:oth eyr:2025 pid:597580472 iyr:2017 hgt:187cm byr:1957 cid:247", true)]
        [InlineData("eyr:2029 cid:145 iyr:2026 pid:178cm hgt:162in ecl:gry hcl:#a5d09f byr:2002", true)]
        public void Task1ValidPasswords(string passportString, bool expected)
        {
            var passport = new Passport(passportString);
            Assert.Equal(expected, passport.ValidIgnoreCid());
        }
        [Fact]
        public void Task1ValidPasswordsFromInput()
        {
            var reader = new InputReader();
            reader.SetInput(@".\testpassportinput.txt");
            var list = reader.ToGroupStringList();
            Assert.Equal(6, list.Count);

            var day4 = new AoCDay4(list);
            var result = day4.PartOne();
            Assert.Equal(5, result);
        }
        [Theory]
        [InlineData("byr:2002", true)]
        [InlineData("byr:2003", false)]
        public void ValidBYR(string passportString, bool expected)
        {
            var passport = new Passport(passportString);
            var actual = passport.ValidBYR();
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("hgt:60in", true)]
        [InlineData("hgt:190cm", true)]
        [InlineData("hgt:190in", false)]
        [InlineData("hgt:190", false)]
        public void ValidHGT(string passportString, bool expected)
        {
            var passport = new Passport(passportString);
            var actual = passport.ValidHGT();
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("hcl:#123abc", true)]
        [InlineData("hcl:#123abz", false)]
        [InlineData("hcl:123abc", false)]
        public void ValidHCL(string passportString, bool expected)
        {
            var passport = new Passport(passportString);
            var actual = passport.ValidHCL();
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("ecl:brn", true)]
        [InlineData("ecl:wat", false)]
        public void ValidECL(string passportString, bool expected)
        {
            var passport = new Passport(passportString);
            var actual = passport.ValidECL();
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("pid:000000001", true)]
        [InlineData("pid:0123456789", false)]
        public void ValidPID(string passportString, bool expected)
        {
            var passport = new Passport(passportString);
            var actual = passport.ValidPID();
            Assert.Equal(expected, actual);
        }
    }
}
