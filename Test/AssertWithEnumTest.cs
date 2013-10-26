using System;
using System.Linq;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AssertsForAll;

namespace AssertsForAll.Test
{
    [TestClass]
    public class AssertWithEnumTest
    {
        public bool TestCode(TestEnum testEnum)
        {
            return testEnum == TestEnum.A;
        }

        public enum TestEnum
        {
            A = 1,
            B = 2,
            C = 3,
            D = 4,
            E = 5
        }

        [TestMethod]
        public void TestCodeShouldReturnTrueOnAAndFalseOnEverythingElse()
        {
            Func<TestEnum, bool> testCode = (e) => 
            {
                return e == TestEnum.A || e == TestEnum.E;
            };
            Asserts.AssertWithEnum<TestEnum, bool>(v => testCode(v), a => a.AllEquals(false)
                                                                           .Except(TestEnum.A, true)
                                                                           .Except(TestEnum.E, true)
                                                                           .Message("Only A and E should be allowed"));
        }
    }
}
