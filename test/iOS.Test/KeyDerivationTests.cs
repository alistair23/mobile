using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using Bit.iOS.Core.Services;

namespace Bit.iOS.Test
{
    [TestFixture]
    public class KeyDerivationTests
    {
        [Test]
        public void MakeKeyFromPasswordBase64()
        {
            var service = new CommonCryptoKeyDerivationService();
            var key = service.DeriveKey(Encoding.UTF8.GetBytes("123456"), Encoding.UTF8.GetBytes("salt"), 5000);
            Assert.True(key.SequenceEqual(GetKey()));
        }

        [Test]
        public void HashPasswordBase64()
        {
            var service = new CommonCryptoKeyDerivationService();
            var hash = service.DeriveKey(GetKey(), Encoding.UTF8.GetBytes("123456"), 1);
            var hashBytes = Convert.FromBase64String("7Bsl4ponrsFu0jGl4yMeLZp5tKqx6g4tLrXhMszIsjQ=");
            Assert.True(hash.SequenceEqual(hashBytes));
        }

        private byte[] GetKey()
        {
            return Convert.FromBase64String("QpSYI5k0bLQXEygUEHn4wMII3ERatuWDFBszk7JAhbQ=");
        }
    }
}
