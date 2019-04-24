using NUnit.Framework;
using SimpleInjector;

namespace SalaryCalculator.ConsoleApp.Test
{
    public class BootstrapperTest
    {
        [Test]
        public void Container_Verify()
        {
            var container = new Container();
            Bootstrapper.Bootstrap(container);
            container.Verify(VerificationOption.VerifyAndDiagnose);
        }
    }
}