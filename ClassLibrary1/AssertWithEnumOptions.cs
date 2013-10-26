using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssertsForAll
{
    public class AssertWithEnumOptions<TEnum, TResult>
    {
        public AssertWithEnumOptions()
        {
            this.Excepts = new Dictionary<TEnum, TResult>();
        }

        public AssertWithEnumOptions<TEnum, TResult> AllEquals(TResult result)
        {
            this.AllEqualsResult = result;
            return this;
        }

        public AssertWithEnumOptions<TEnum, TResult> Except(TEnum enumValue, TResult result)
        {
            this.Excepts.Add(enumValue, result);
            return this;
        }

        public AssertWithEnumOptions<TEnum, TResult> Message(string message)
        {
            this.AssertMessage = message;
            return this;
        }

        public IDictionary<TEnum, TResult> Excepts { get; private set; }

        public TResult AllEqualsResult { get; private set; }

        public string AssertMessage { get; private set; }
    }
}
