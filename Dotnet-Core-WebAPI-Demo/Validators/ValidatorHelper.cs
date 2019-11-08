using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet_Core_WebAPI_Demo.Validators
{
    public sealed class ValidatorHelper // sealed ensures this can't be inherited even within this class itself
    {
        private ValidatorHelper(){} // ensures that object is not instantiated other then with in this class itself

        private static ValidatorHelper instance = null;
        public static ValidatorHelper GetInstance  // Singleton design pattern
        {
            get
            {
                if (instance == null)
                    instance = new ValidatorHelper();
                return instance;
            }
        }
        public bool BeAValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("_", "");
            return name.All(Char.IsLetter);
        }
    }
}
