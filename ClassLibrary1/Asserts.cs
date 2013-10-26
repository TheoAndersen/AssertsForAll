using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssertsForAll
{
    public class Asserts
    {
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
