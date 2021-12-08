using System;
using System.Reflection;

namespace UnitTestProject
{
    public abstract class AbstractTest
    {
        protected MethodInfo GetMethod(int day, int part)
        {
            Type type = Type.GetType($"AdventOfCode.Day{day}.Day{day}, AdventOfCode");
            return type.GetMethod("ExecutePart" + part);
        }
    }
}
