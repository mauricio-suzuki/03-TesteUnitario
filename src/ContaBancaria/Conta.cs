namespace ContaBancaria;


public class Conta
{
    public string Titular { get; private set; }
    public decimal Saldo { get; private set; }
    public bool Ativa { get; private set; }

    public Conta(string titular, decimal saldoInicial = 0)
    {
        if (string.IsNullOrWhiteSpace(titular))
            throw new ArgumentException("O titular não pode ser nulo ou vazio.", nameof(titular));
        if (saldoInicial < 0)
            throw new ArgumentException("O saldo inicial não pode ser negativo.", nameof(saldoInicial));

        Titular = titular;
        Saldo = saldoInicial;
        Ativa = true;
    }

    public void Depositar(decimal valor)
    {
        if (!Ativa)
            throw new InvalidOperationException("Conta inativa");
        if (valor <= 0)
            throw new ArgumentException("Valor deve ser maior que zero");
        Saldo += valor;
    }

    public void Sacar(decimal valor)
    {
        if (!Ativa)
            throw new InvalidOperationException("Conta inativa");

        if (valor <= 0)
            throw new ArgumentException("Valor deve ser maior que zero");

        if (Saldo < valor)
            throw new InvalidOperationException("Saldo insuficiente");

        Saldo -= valor;
    }

    public void Transferir(Conta destino, decimal valor)
    {
        if (!Ativa)
            throw new InvalidOperationException("Conta origem inativa");
        if (!destino.Ativa)
            throw new InvalidOperationException("Conta destino inativa");
        if (valor <= 0)
            throw new ArgumentException("Valor deve ser maior que zero");
        if (Saldo < valor)
            throw new InvalidOperationException("Saldo insuficiente");

        Saldo -= valor;
        destino.Saldo += valor;
    }

  


    public void Encerrar()
    {
        if (!Ativa)
            throw new InvalidOperationException("Conta já inativa");

        if (Saldo != 0)
            throw new InvalidOperationException("Conta com saldo não pode ser encerrada");

        Ativa = false;
    }
}
