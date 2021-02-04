using src.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====  Seção 17: Exercício proposto LINQ" + Environment.NewLine);

            string pastaInput = @"C:\Users\alvar\OneDrive\Workspaces\ws-vs2019\cs-vs2019-secao-17-exercicio-proposto-LINQ\io\";
            string arquivoInput = @"input.txt";

            List<Usuario> usuarios = new List<Usuario>();

            using (StreamReader sr = new StreamReader(new FileStream(pastaInput + arquivoInput, FileMode.Open)))
            {
                while (!sr.EndOfStream)
                {
                    string[] linha = sr.ReadLine().Split(',');
                    string nome = linha[0];
                    string email = linha[1];
                    double salario = double.Parse(linha[2], CultureInfo.InvariantCulture);

                    Usuario usuario = new Usuario(nome,email,salario);
                    usuarios.Add(usuario);
                }
            }

            Console.Write("Salário da consulta: R$ ");
            double salarioConsulta = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            var emailsConsulta = usuarios.Where(u => u.Salario >= salarioConsulta).OrderBy(u => u.Nome).Select(u => u.email);

            Console.WriteLine();
            Console.WriteLine($"Usuários com salário maior que R$ {salarioConsulta.ToString("F2", CultureInfo.InvariantCulture)}");
            foreach(string email in emailsConsulta)
            {
                Console.WriteLine(email);
            }
            Console.WriteLine();

            var soma = usuarios.Where(u => u.Nome.ToUpper()[0] == 'M').Select(u => u.Salario).DefaultIfEmpty(0.0).Sum();
            Console.WriteLine($"Salário dos usuários com nome começados pela letra M: R$ {soma.ToString("F2", CultureInfo.InvariantCulture)}");

        }
    }
}
