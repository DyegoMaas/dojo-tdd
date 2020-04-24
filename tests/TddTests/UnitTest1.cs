using System;
using FluentAssertions;
using Xunit;

namespace TddTests
{
    public class UnitTest1
    {
        private readonly StringCalculator _calculadora;

        public UnitTest1()
        {
            
            _calculadora = new StringCalculator();

        }
        [Fact]
        public void Deve_retornar_zero_quando_o_input_for_vazio()
        {
            
            int soma = _calculadora.Adicionar("");

            soma.Should().Be(0);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("10", 10)]
        [InlineData("15", 15)]
        public void Deve_retornar_o_mesmo_numero_se_ele_vier_sozinho(string numeros, int resultadoEsperado)
        {          
            int soma = _calculadora.Adicionar(numeros);

            soma.Should().Be(resultadoEsperado);
        }
        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("10, 1", 11)]
        [InlineData("-15, -25", -40)]
        public void Deve_retornar_soma_dos_dois_numeros_informados(string numeros, int resultadoEsperado)
        {
            int soma = _calculadora.Adicionar(numeros);

            soma.Should().Be(resultadoEsperado);
        }
    }

    public class StringCalculator
    {
        public int Adicionar(string numeros)
        {
            if (numeros == string.Empty)
            {
                return 0;
            }
            else
            {
                return int.Parse(numeros);
            }
        }
    }
}