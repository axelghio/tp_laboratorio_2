using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using EntidadesAbstractas;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class TestExeption
    {
        [TestMethod]
        public void AlumnoRepetido()
        {
            try
            {
                Alumno alm = new Alumno(5, "Roberto", "Carlos", "37556558", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Alumno alm2 = new Alumno(5, "Roberto", "Carlos", "37556558", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }
        public void DniInvalido()
        {
            try
            {
                Alumno alm = new Alumno(5, "Roberto", "Carlos", "123abc", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);    Alumno alm2 = new Alumno(5, "Roberto", "Carlos", "37556558", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }
    }
}
