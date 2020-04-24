using System;
using FluentAssertions;
using Xunit;

namespace TddTests
{
    public class UnitTest1
    {
        [Fact]
        public void Deve_retornar_zero_quando_o_input_for_vazio()
        {
            var calculadora = new StringCalculator();

            int soma = calculadora.Adicionar("");

            soma.Should().Be(0);
        }

        [Fact]
        public void Deve_retornar_o_mesmo_numero_se_ele_vier_sozinho()
        {
            var calculadora = new StringCalculator();

            int soma = calculadora.Adicionar("1");

            soma.Should().Be(1);
        }
    }

    public class StringCalculator
    {
        public int Adicionar(string numeros)
        {
            return 0;
        }
    }
}