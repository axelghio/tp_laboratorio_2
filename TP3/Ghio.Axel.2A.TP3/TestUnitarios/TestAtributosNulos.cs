using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using EntidadesAbstractas;

namespace TestUnitarios
{
    [TestClass]
    public class TestAtributosNulos
    {
        [TestMethod]
        public void AtributosNulos()
        {
            Profesor prof = new Profesor(10, "Axel", "Ghio", "37558556", Persona.ENacionalidad.Argentino);
            Assert.IsNotNull(prof);
        }
    }
}
