using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Giwer.workflowBuilder
{
    class WorkflowItem
    {
        private PropertyInfo[] _ownProperties;

        public Type Operation { get; private set; }

        public Dictionary<string, string> Parameters { get; private set; }

        public WorkflowItem(Type operation)
        {
            Operation = operation;
            _ownProperties = Operation
                .GetProperties()
                .Where(prop => prop.DeclaringType == Operation)
                .ToArray();

            Parameters = new Dictionary<string, string>();
            foreach (var prop in _ownProperties)
            {
                Parameters.Add(prop.Name, string.Empty);
            }
        }

        public override string ToString()
        {
            var ownProperties = Operation
                .GetProperties()
                .Where(prop => prop.DeclaringType == Operation);

            return $"{Operation.Name} ({ownProperties.Count()})";
        }
    }
}