using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] requestedFields)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classFields = classType.GetFields(
                BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.NonPublic |
                BindingFlags.Public);

            var classInstance = Activator.CreateInstance(classType);

            var sb = new StringBuilder();
            sb.AppendLine(String.Format("Class under investigation: {0}", classType.Name));

            foreach (var field in classFields.Where(f => requestedFields.Contains(f.Name)))
            {
                sb.AppendLine(String.Format("{0} = {1}", field.Name, field.GetValue(classInstance)));
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAcessModifiers(string className)
        {
            var classType = Type.GetType(className);

            FieldInfo[] publicFields = classType.GetFields(
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.Instance);

            MethodInfo[] publicMethods = classType.GetMethods(
                BindingFlags.Public |
                BindingFlags.Instance);

            MethodInfo[] privateMethods = classType.GetMethods(
                BindingFlags.NonPublic|
                BindingFlags.Instance);

            var sb = new StringBuilder();

            foreach (var field in publicFields)
            {
                sb.AppendLine(String.Format("{0} must be private!", field.Name));
            }

            foreach (var getter in privateMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine(String.Format("{0} have to be public!", getter.Name));
            }

            foreach (var setter in publicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine(String.Format("{0} have to be private!", setter.Name));
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            var classType = Type.GetType(className);

            var baseClassName = classType.BaseType.Name;
            MethodInfo[] privateMethods = classType.GetMethods(
                BindingFlags.Instance |
                BindingFlags.NonPublic);

            var sb = new StringBuilder();
            sb
                .AppendLine($"All Private Methods of Class: {className}")
                .AppendLine($"Base Class: {baseClassName}");

            foreach (var method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string className)
        {
            var classType = Type.GetType(className);
            var allMethods = classType.GetMethods(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.Static);

            var getters = ExtractGetters(allMethods);
            var setters = ExtractSetters(allMethods);

            var sb = new StringBuilder();

            foreach (var getter in getters)
            {
                sb.AppendLine($"{getter.Name} will return {getter.ReturnType}");
            }

            foreach (var setter in setters)
            {
                sb.AppendLine($"{setter.Name} will set field of {setter.GetParameters().First().ParameterType}");
            }

            return sb.ToString().TrimEnd();
        }

        private IEnumerable<MethodInfo> ExtractGetters(MethodInfo[] methods)
            => methods.Where(m => m.Name.StartsWith("get"));

        private IEnumerable<MethodInfo> ExtractSetters(MethodInfo[] methods)
            => methods.Where(m => m.Name.StartsWith("set"));
    }
}
