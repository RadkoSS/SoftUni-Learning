namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);

            FieldInfo field = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(x => x.Name == "innerValue");

            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);

            ConstructorInfo constructorWithParameter = constructors.FirstOrDefault(x => x.GetParameters().Length == 1);

            BlackBoxInteger bbi = constructorWithParameter?.Invoke(new object[] { 0 }) as BlackBoxInteger;

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] args = command?.Split('_');

                string methodName = args?[0];

                int value = int.Parse(args![1]);

                MethodInfo searchedMethod = methods.FirstOrDefault(x => x.Name == methodName);

                searchedMethod?.Invoke(bbi, new object[] { value });

                int currentValueOfField = (int) field?.GetValue(bbi)!;

                Console.WriteLine(currentValueOfField);
            }
        }
    }
}
