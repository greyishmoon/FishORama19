using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishLibrary
{
    /// <summary>
    /// TokenManager class - a class to manage Token interactions
    /// </summary>
    public class TokenManager : ITokenManager
    {

        private ChickenLeg chickenLeg;                      // Stores a reference to the chicken leg while it's on the screen

        public ChickenLeg ChickenLeg { get => chickenLeg;}  // Property to access chickenLeg variable

        /// <summary>
        /// Constructor for the TokenManager class - run once only when an object of the class is INSTANTIATED (created)
        /// </summary>
        public TokenManager()
        {
            chickenLeg = null;                              // Defualt variable to null
        }

        /// <summary>
        /// Sets chickenLeg variable
        /// </summary>
        /// <param name="pToken">the ChickenLeg object to be set</param>
        public void SetChickenLeg(ChickenLeg pChickenLeg)
        {
            chickenLeg = pChickenLeg;
        }

    }
}
