using System;

namespace DIO.Series
{
    public class Senha
    {
        int senha;

        public Senha(int senha) 
        {
            this.senha = senha;
        }

        public String validarSenha()
        {
            Console.Write("Digite a senha novamente para validação ");
            int validaSenha = int.Parse(Console.ReadLine());

            if(validaSenha == senha)
            {
                Console.WriteLine("Senha validada com sucesso!!");
            } else 
            {
                throw new ArgumentOutOfRangeException();
            }

            return "Acesso Liberado!";        
        }
    }
}