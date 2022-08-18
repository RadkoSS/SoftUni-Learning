 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = typeof(HarvestingFields);

            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

            FieldInfo[] publicFields = fields.Where(x => x.IsPublic).ToArray();
            FieldInfo[] privateFields = fields.Where(x => x.IsPrivate).ToArray();
            FieldInfo[] protectedFields = fields.Where(x => x.IsFamily).ToArray();

            string command = string.Empty;

            while ((command = Console.ReadLine()?.ToLower()) != "harvest")
            {
                if (command == "public")
                {
                    Print(publicFields);
                }
                else if (command == "protected")
                {
                    Print(protectedFields);
                }
                else if (command == "private")
                {
                    Print(privateFields);
                }
                else if (command == "all")
                {
                    Print(fields);
                }
            }
        }

        public static void Print(FieldInfo[] fields)
        {
            foreach (var field in fields)
            {
                Console.WriteLine(ReturnResult(field));
            }
        }

        public static string ReturnResult(FieldInfo field)
        {
            if (field.IsPrivate)
            {
                return $"private {field.FieldType.Name} {field.Name}";
            }

            if (field.IsFamily)
            {
                return $"protected {field.FieldType.Name} {field.Name}";
            }

            return $"public {field.FieldType.Name} {field.Name}";
        }
    }
}
