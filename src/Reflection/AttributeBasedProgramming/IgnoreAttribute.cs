using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeBasedProgramming;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
internal class IgnoreAttribute : Attribute
{
}
