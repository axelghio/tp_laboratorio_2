using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Test
{
    [TestClass]
    public class TestCorreo
    {
        /// <summary>
        /// Metodo para testear si un correo es valido y no null.
        /// </summary>
        [TestMethod]
        public void TestValidarCorreo()
        {
            Correo c = new Correo();
            Assert.IsNotNull(c.Paquetes);
        }

        /// <summary>
        /// Metodo para validar si hay paquetes iguales.
        /// </summary>
        [TestMethod]
        public void TestValidarPaquetesIGuales()
        {
            Correo c = new Correo();
            try
            {
                Paquete p1 = new Paquete("mitre", "1234567890");
                Paquete p2 = new Paquete("santa fe", "1234567890");
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
