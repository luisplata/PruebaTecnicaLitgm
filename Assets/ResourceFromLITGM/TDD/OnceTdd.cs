using Mathematics;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace ResourceFromLITGM.TDD
{
    public class OnceTdd
    {
        // A Test behaves as an ordinary method
        [Test]
        public void OnceTddSimplePasses()
        {
            // Use the Assert class to test conditions
            var subtitute = Substitute.For<ISimulatorView>();
            var calc = new Calculating(1, 1, subtitute);


            var result = calc.CalcParabolic3D(Vector3.zero, Vector3.zero, 0);
            
            Assert.AreEqual(result, Vector3.up);
        }
    }
}
