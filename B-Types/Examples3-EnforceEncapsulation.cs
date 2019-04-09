using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public class EnforceEncapsulation
    {
        #region Access Modifiers Example

        public void RunAccessModifiersExamples()
        {
            // --------------------------------------------------------------------------------------------
            // - Access modifiers https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/access-modifiers
            //   Not much to show here except that there are six types of access modifiers
            //   - public .............. No restriction
            //   - protected ........... Only derived types
            //   - internal ............ No restriction within the same assembly
            //   - protected internal .. Only derived types and no restriction within the same assembly
            //   - private ............. Only within the class
            //   - private protected ... Only within the class or derived types which are in the same assembly
            //
            // - Access modifiers with class or struct https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers
            // 
            //   Access modfiers in class have the following properties:
            //   - Default modifier is private
            //   - All above modifiers are allowed
            // 
            //   Access modifiers in struct have the following properties:
            //   - Default modifier is private
            //   - Only public, internal and privat are allowed.
            //      
        }

        #endregion 
    }
}
