using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssertsForAll
{
    /// <summary>
    /// Options for AsserWithEnum
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class AssertWithEnumOptions<TEnum, TResult>
    {
        public IDictionary<TEnum, TResult> Excepts { get; private set; }
        public TResult AllEqualsResult { get; private set; }
        public string AssertMessage { get; private set; }

        public AssertWithEnumOptions()
        {
            this.Excepts = new Dictionary<TEnum, TResult>();
        }

        /// <summary>
        /// The result asserted on if no Except() is given
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public AssertWithEnumOptions<TEnum, TResult> AllEquals(TResult result)
        {
            this.AllEqualsResult = result;
            return this;
        }

        /// <summary>
        /// Exceptions to the given AllEquals result
        /// </summary>
        /// <param name="enumValue"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public AssertWithEnumOptions<TEnum, TResult> Except(TEnum enumValue, TResult result)
        {
            this.Excepts.Add(enumValue, result);
            return this;
        }

        /// <summary>
        /// Assertion message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public AssertWithEnumOptions<TEnum, TResult> Message(string message)
        {
            this.AssertMessage = message;
            return this;
        }

    }
}
