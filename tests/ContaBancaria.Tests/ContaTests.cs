using Xunit;
using ContaBancaria;

namespace ContaBancaria.Tests;

/// <summary>
/// Testes unitários para a classe Conta.
/// 
/// PARTE 1 — Testes de exemplo (Construtor) já estão prontos.
///           Observe o padrão AAA e o uso de [Fact] e [Theory].
///
/// PARTE 2 — Você deve escrever os testes para os demais métodos
///           seguindo rigorosamente o ciclo TDD: Red → Green → Refactor.
///
/// Para cada método da classe Conta, crie testes que cubram:
///   ✅ O cenário de sucesso (caminho feliz)
///   ❌ Cada regra de validação (cenários de exceção)
///   🔄 Casos de borda (valores limites)
/// </summary>
public class ContaTests
{
    // =======================================================
    //  PARTE 1 — EXEMPLO GUIADO: Testes do Construtor
    //  Observe o padrão Arrange-Act-Assert (AAA)
    // =======================================================

    [Fact]
    public void Construtor_DadosValidos_CriaContaCorretamente()
    {
        // Arrange & Act
        var conta = new Conta("Maria", 100);

        // Assert
        Assert.Equal("Maria", conta.Titular);
        Assert.Equal(100, conta.Saldo);
        Assert.True(conta.Ativa);
    }

    [Fact]
    public void Construtor_SemSaldoInicial_CriaContaComSaldoZero()
    {
        // Arrange & Act
        var conta = new Conta("João");

        // Assert
        Assert.Equal("João", conta.Titular);
        Assert.Equal(0, conta.Saldo);
        Assert.True(conta.Ativa);
    }

    [Fact]
    public void Construtor_TitularNulo_LancaArgumentException()
    {
        // Assert — verifica que a exceção é lançada
        Assert.Throws<ArgumentException>(() => new Conta(null!));
    }

    [Fact]
    public void Construtor_TitularVazio_LancaArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Conta(""));
    }

    [Fact]
    public void Construtor_SaldoNegativo_LancaArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Conta("Maria", -50));
    }

    [Theory]
    [InlineData("Ana", 0)]
    [InlineData("Carlos", 1000)]
    [InlineData("Beatriz", 0.01)]
    public void Construtor_VariosValoresValidos_CriaContaCorretamente(string titular, decimal saldo)
    {
        // Act
        var conta = new Conta(titular, saldo);

        // Assert
        Assert.Equal(titular, conta.Titular);
        Assert.Equal(saldo, conta.Saldo);
        Assert.True(conta.Ativa);
    }

    // =======================================================
    //  PARTE 2 — ESCREVA OS TESTES ABAIXO (TDD)
    //  Lembre-se: escreva o teste PRIMEIRO, veja FALHAR (Red),
    //  depois implemente o código para PASSAR (Green),
    //  e por fim faça Refactor se necessário.
    // =======================================================

    [Fact]
    public void Depositar_ValorValido_AtualizaSaldo()
    {
        // Arrange
        var conta = new Conta("Maria", 100);

        // Act
        conta.Depositar(50);

        // Assert
        Assert.Equal(150, conta.Saldo);
    }

    [Fact]
    public void Depositar_ValorZero_LancaArgumentException()
    {
        // Arrange
        var conta = new Conta("Maria", 100);

        // Act + Assert
        Assert.Throws<ArgumentException>(() => conta.Depositar(0));
    }

    [Fact]
    public void Depositar_ValorNegativo_LancaArgumentException()
    {
        // Arrange
        var conta = new Conta("Maria", 100);

        // Act + Assert
        Assert.Throws<ArgumentException>(() => conta.Depositar(-10));
    }

    [Fact]
    public void Depositar_ContaInativa_LancaInvalidOperationException()
    {
        // Arrange
        var conta = new Conta("Maria", 0);
        conta.Encerrar();

        // Act + Assert
        Assert.Throws<InvalidOperationException>(() => conta.Depositar(10));
    }
[Fact]
public void Sacar_ValorValido_DiminuiSaldo()
{
    // Arrange
    var conta = new Conta("Maria", 100);

    // Act
    conta.Sacar(40);

    // Assert
    Assert.Equal(60, conta.Saldo);
}

[Fact]
public void Sacar_SaldoInsuficiente_LancaInvalidOperationException()
{
    var conta = new Conta("Maria", 50);

    Assert.Throws<InvalidOperationException>(() => conta.Sacar(100));
}

[Fact]
public void Sacar_ValorZero_LancaArgumentException()
{
    var conta = new Conta("Maria", 50);

    Assert.Throws<ArgumentException>(() => conta.Sacar(0));
}
[Fact]
public void Sacar_ValorNegativo_LancaArgumentException()
{
    var conta = new Conta("Maria", 50);

    Assert.Throws<ArgumentException>(() => conta.Sacar(-10));
}

[Fact]
public void Sacar_ContaInativa_LancaInvalidOperationException()
{
    var conta = new Conta("Maria", 0);
    conta.Encerrar();

    Assert.Throws<InvalidOperationException>(() => conta.Sacar(10));
}

[Fact]
public void Transferir_ValorValido_AtualizaSaldoDeAmbasContas()
{
    // Arrange
    var origem = new Conta("Maria", 200);
    var destino = new Conta("João", 100);

    // Act
    origem.Transferir(destino, 50);

    // Assert
    Assert.Equal(150, origem.Saldo);
    Assert.Equal(150, destino.Saldo);
}

[Fact]
public void Transferir_SaldoInsuficiente_LancaInvalidOperationException()
{
    var origem = new Conta("Maria", 50);
    var destino = new Conta("João", 100);

    Assert.Throws<InvalidOperationException>(() => origem.Transferir(destino, 100));
}

[Theory]
[InlineData(0)]
[InlineData(-10)]
public void Transferir_ValorInvalido_LancaArgumentException(decimal valor)
{
    var origem = new Conta("Maria", 100);
    var destino = new Conta("João", 100);

    Assert.Throws<ArgumentException>(() => origem.Transferir(destino, valor));
}

[Fact]
public void Transferir_ContaOrigemInativa_LancaInvalidOperationException()
{
    var origem = new Conta("Maria", 100);
    var destino = new Conta("João", 100);

    // Tornar conta inativa apenas para o teste
    typeof(Conta).GetProperty("Ativa")!.SetValue(origem, false);

    Assert.Throws<InvalidOperationException>(() => origem.Transferir(destino, 50));
}

[Fact]
public void Transferir_ContaDestinoInativa_LancaInvalidOperationException()
{
    var origem = new Conta("Maria", 100);
    var destino = new Conta("João", 100);

    // Tornar conta destino inativa apenas para o teste
    typeof(Conta).GetProperty("Ativa")!.SetValue(destino, false);

    Assert.Throws<InvalidOperationException>(() => origem.Transferir(destino, 50));
}
[Fact]
public void Encerrar_ContaComSaldoZero_Funciona()
{
    var conta = new Conta("Maria", 0);

    conta.Encerrar();

    Assert.False(conta.Ativa);
}

[Fact]
public void Encerrar_ContaComSaldo_LancaInvalidOperationException()
{
    var conta = new Conta("Maria", 100);

    Assert.Throws<InvalidOperationException>(() => conta.Encerrar());
}

[Fact]
public void Encerrar_ContaJaInativa_LancaInvalidOperationException()
{
    var conta = new Conta("Maria", 0);
    conta.Encerrar();

    Assert.Throws<InvalidOperationException>(() => conta.Encerrar());
}



}
