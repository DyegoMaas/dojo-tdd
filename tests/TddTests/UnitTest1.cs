using System;
using FluentAssertions;
using Xunit;

namespace TddTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var calculadora = new StringCalculator();

            int soma = calculadora.Adicionar("");

            soma.Should().Be(0);
        }
    }

    public class StringCalculator
    {
        public int Adicionar(string numeros)
        {
            throw new NotImplementedException();
        }
    }
}