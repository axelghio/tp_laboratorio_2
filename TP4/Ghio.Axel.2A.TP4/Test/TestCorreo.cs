using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Test
{
    [TestClass]
    public class TestCorreo
    {
        [TestMethod]
        public void TestValidarCorreo()
        {
            Correo c = new Correo();
            Assert.IsNotNull(c.Paquetes);
        }

        [TestMethod]
        public void TestValidarPaquetesIGuales()
        {
            Correo c = new Correo();
            try
            {
                Paquete p1 = new Paquete("mitre", "123123123");
                Paquete p2 = new Paquete("santa fe", "123123123");
                c += p1;
                c += p2;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrakeingIdRepetidoException));
            }
        }


    }
}
