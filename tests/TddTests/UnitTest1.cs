using System;
using System.Linq;
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
            var soma = _calculadora.Adicionar("");
            
            soma.Should().Be(0);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("10", 10)]
        [InlineData("15", 15)]
        public void Deve_retornar_o_mesmo_numero_se_ele_vier_sozinho(string numeros, int resultadoEsperado)
        {          
            var soma = _calculadora.Adicionar(numeros);

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
        
        [Theory]
        [InlineData("10\n1", 11)]
        [InlineData("-15\n-25,1", -39)]
        public void Deve_aceitar_barra_n_como_limitador(string numeros, int resultadoEsperado)
        {
            int soma = _calculadora.Adicionar(numeros);

            soma.Should().Be(resultadoEsperado);
        }

        [Theory]
        [InlineData("1\n,2")]
        [InlineData("1,\n2")]
        public void Deve_atirar_uma_excecao_se_colocar_um_delimitador_apos_o_outro(string numeros)
        {
            var adicionar = new Action(() => _calculadora.Adicionar(numeros));

            adicionar.Should().Throw<InvalidOperationException>();
        }
    }

    public class StringCalculator
    {
        public int Adicionar(string input)
        {
            if (input == string.Empty)
            {
                return 0;
            }

            var delimitadores = new[] {',', '\n'};
            var soma = input
                .Split(delimitadores)
                .Select(int.Parse)
                .Sum();
            return soma;
        }
    }
}