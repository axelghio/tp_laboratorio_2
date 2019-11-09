using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using EntidadesAbstractas;

namespace TestUnitarios
{
    [TestClass]
    public class TestValoresNumericos
    {
        [TestMethod]
        public void ValoresNumericos()
        {
            Alumno alm = new Alumno(1,"Joe","Suarez","18555666", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            Assert.IsInstanceOfType(alm.DNI, typeof(int));
        }
    }
}
