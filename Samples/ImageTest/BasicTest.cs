using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCvSharp;

namespace ImageTest
{
    [TestClass]
    public class BasicTest
    {
        [TestMethod]
        public void CreateDispose()
        {
            var width = 640;
            var height = 480;
            using var a = new Mat(height, width, MatType.CV_32F);
            var value = 1.0;
            a.SetTo(value);
            a.MinMaxLoc(out double minValue, out double maxValue);
            Assert.AreEqual(value, minValue);
            Assert.AreEqual(value, maxValue);
        }
    }
}
