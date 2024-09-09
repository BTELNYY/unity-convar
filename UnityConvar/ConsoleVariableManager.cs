using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using UnityConvar.Attributes;

namespace UnityConvar
{
    public class ConsoleVariableManager
    {
        private static bool _init = false;

        private static List<GenericConsoleVariable> currentConvars = new List<GenericConsoleVariable>();

        public static GenericConsoleVariable GetVariable(string name)
        {
            GenericConsoleVariable variable = currentConvars.Find(x => x.Name == name);
            return variable;
        }

        public static GenericConsoleVariable[] GetAllConsoleVariables()
        {
            return currentConvars.Where(x => !x.Flags.HasFlag(ConvarFlags.Hidden)).ToArray();
        }

        public static int GetVariableIndex(string name)
        {
            return currentConvars.FindIndex(x => x.Name == name);
        }

        public static void SetVariable(string name, string value)
        {
            int index = GetVariableIndex(name);
            currentConvars[index].SetValueGeneric(value, false);
        }

        public static void SetVariable(int index, GenericConsoleVariable variable)
        {
            currentConvars[index] = variable;
        }

        public static void AddVariable(GenericConsoleVariable variable)
        {
            if (currentConvars.Contains(variable))
            {
                return;
            }
            currentConvars.Add(variable);
        }

        public static void RemoveVariable(int index)
        {
            currentConvars.RemoveAt(index);
        }

        public static void RemoveVariable(string name)
        {
            RemoveVariable(GetVariableIndex(name));
        }

        private static Dictionary<Type, Type> typeToConVarClass = new Dictionary<Type, Type>();

        public static Type GetConVarClass(Type type)
        {
            if (!typeToConVarClass.ContainsKey(type))
            {
                return null;
            }
            else
            {
                return typeToConVarClass[type];
            }
        }

        public static bool HasConVarClass(Type type)
        {
            return typeToConVarClass.ContainsKey(type);
        }

        public static void AddConVarClass(Type type, Type conVarClass)
        {
            if (typeToConVarClass.ContainsKey(type))
            {
                return;
            }
            typeToConVarClass.Add(type, conVarClass);
        }

        public static void RemoveConVarClass(Type type)
        {
            if (!typeToConVarClass.ContainsKey(type))
            {
                return;
            }
            typeToConVarClass.Remove(type);
        }

        static ConsoleVariableManager()
        {
            if (!_init)
            {
                LoadFromAssembly(Assembly.GetExecutingAssembly());
                _init = true;
            }
        }

        public static void LoadFromAssembly(Assembly assembly)
        {
            List<Type> customConvarClasses = assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(GenericConsoleVariable)) && x.GetCustomAttribute<ConsoleVariableTypeAttribute>() != null).ToList();
            foreach (Type t in customConvarClasses)
            {
                GenericConsoleVariable @class = (GenericConsoleVariable)Activator.CreateInstance(t);
                Type targetType = @class.ValueType;
                if (typeToConVarClass.ContainsKey(targetType))
                {
                    continue;
                }
                else
                {
                    typeToConVarClass.Add(targetType, t);
                }
            }
            List<Type> customConvars = assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(GenericConsoleVariable)) && x.GetCustomAttribute<ConsoleVariableAttribute>() != null).ToList();
            foreach(Type t in customConvars)
            {
                GenericConsoleVariable convar = (GenericConsoleVariable)Activator.CreateInstance(t);
                if (currentConvars.Contains(convar))
                {
                    continue;
                }
                else
                {
                    currentConvars.Add(convar);
                }
            }
        }
    }
}
