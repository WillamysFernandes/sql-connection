using System;
using System.Data.SqlClient;

namespace HappyBirthDay
{
    class Program
    {
        static void Main(string[] args)
        {
            var _connnection="Data Source=DESKTOP-8U0OIEV;Initial Catalog=balta;Integrated Security=True";

            using (var con = new SqlConnection(_connnection))

            {
                con.Open();
                using(var command = new SqlCommand()){
                    command.Connection = con;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT[Title] FROM [Category]";

                    var read = command.ExecuteReader();
                    while (read.Read())

                    {
                        Console.WriteLine($"{read.GetString(0)}");    
                    }

                }
            }
            var aniversariantes = new Aniversariante().GetAniversariantes();//Chamando minha lista de Aniversariantes


            if (aniversariantes.Count == 0)
            {
                Console.WriteLine("Nenhum Aniversariante no dia de hoje");
            }
            else
            {
                foreach (var A in aniversariantes)
                {
                    var anos = DateTime.Now.Year - A.DataNascimento.Year;
                    Console.WriteLine($"Parabéns {A.Nome}, pelos seus {anos} de idade");
                }
            }


        }
    }

    public class Aniversariante //Classe 

    {
        private List<Aniversariante> _aniversariantes { get; set; }
        public string Nome { get; set; } //Propriedades da classe
        public DateTime DataNascimento { get; set; }
        public Aniversariante(string nome, DateTime datanascimento) //Construtor da linha classe
        {
            Nome = nome;
            DataNascimento = datanascimento;//Atribundo os parâmetros
            _aniversariantes = new List<Aniversariante>{

            new Aniversariante("Enderson Amorim", new DateTime(1994, 09, 01)),
            new Aniversariante("Eduardo Lopes", new DateTime(1997, 07, 18)),
            new Aniversariante("Marcos Araújo", new DateTime(2000, 02, 23)),
            new Aniversariante("Willamys Fernandes", new DateTime(1996, 02, 23))
            };



        }
        public Aniversariante()
        {

        }

        private static List<Aniversariante> MeusDados() //Metodo para chamar sempre que quiser criar uma nova lista do tipo:Aniversariante
        {
            var aniversariante = new List<Aniversariante>();
            aniversariante.Add(new Aniversariante("Enderson Amorim", new DateTime(1994, 09, 01)));
            aniversariante.Add(new Aniversariante("Eduardo Lopes", new DateTime(1997, 07, 18)));
            aniversariante.Add(new Aniversariante("Marcos Araújo", new DateTime(2000, 02, 23)));
            aniversariante.Add(new Aniversariante("Willamys Fernandes", new DateTime(1996, 02, 23)));

            return aniversariante;//O retorno da minha lista criada

        }
        public List<Aniversariante> GetAniversariantes()
        {

            return _aniversariantes.Where(f => f.DataNascimento.Day == DateTime.Now.Day && f.DataNascimento.Month == DateTime.Now.Month).ToList();
        }
    }

}