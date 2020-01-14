using System;
using System.Collections.Generic;
using System.Linq;
using Xunit.Sdk;

namespace Xunit.Extensions
{
    public static class AssertAll
    {
        public static void Exceute(params Action[] assertionsToRun)
        {
            var errorMessages = new List<Exception>();
            foreach (var action in assertionsToRun)
            {
                try
                {
                    action.Invoke();
                }
                catch (Exception exception)
                {
                    errorMessages.Add(exception);
                }
            }

            if (!errorMessages.Any())
            {
                return;
            }

            var errorMessage = string.Join("\n\n", errorMessages);
            throw new XunitException($"The following conditions failed:\n\n{errorMessage}");
        }
    }
}
