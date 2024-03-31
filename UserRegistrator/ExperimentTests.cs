using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegClasses;

namespace UserRegistratorTest
{
    public class ExperimentTests
    {

        [Fact]
        public void Test_Experimental_Error_Handler()
        {
            
            var user = new UserExperiment("Skit", "skit", "skit");
            var errors = user.errorHandler();

            if (errors != null)
            {
                foreach (var error in errors) 
                {
                    Debug.WriteLine(error.Message);
                }
            }
            Assert.Equal(3, errors.Count);
        }



    }
}
