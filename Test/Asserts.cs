using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssertsForAll
{
    public class Asserts
    {
        /// <summary>
        /// Tests some code multiple times for each value of a given enumerator and asserts on the response after the given rules in options.
        /// </summary>
        /// <typeparam name="TEnum">The enumerator type for which all values will be tested</typeparam>
        /// <typeparam name="TResult">The result type which will be asserted on</typeparam>
        /// <param name="testMethod">The method which will be tested with each of the enumerator values</param>
        /// <param name="getOptions">Configurable options on which results will be expected when testing each enumerator value</param>
        public static void AssertWithEnum<TEnum, TResult>(Func<TEnum, TResult> testMethod, Func<AssertWithEnumOptions<TEnum, TResult>, AssertWithEnumOptions<TEnum, TResult>> getOptions)
        {
            string[] enumNames = Enum.GetNames(typeof(TEnum));
            var options = getOptions(new AssertWithEnumOptions<TEnum, TResult>());

            foreach (string name in enumNames)
            {
                TEnum enumValue = (TEnum)Enum.Parse(typeof(TEnum), name);

                if (options.Excepts.ContainsKey(enumValue))
                {
                    TResult keyResult = options.Excepts[enumValue];
                    Assert.AreEqual(keyResult, testMethod(enumValue), typeof(TEnum).ToString() + "." + name);
                }
                else
                {
                    Assert.AreEqual(options.AllEqualsResult, testMethod(enumValue), "AssertWithEnum failed with enum value: " + typeof(TEnum).ToString() + "." + name + " (" + options.AssertMessage + ")");
                }
            }
        }
    }
}
