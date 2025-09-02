// Adicione para usar Expressões Regulares
using System.Text.RegularExpressions;
namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // implementação de verificação de placa valida, mercosul ou padrão
            // Laço de repetição para garantir que uma placa válida seja inserida
            while (true)
            {
                Console.WriteLine("Digite a placa do veículo para estacionar (formato ABC-1234 ou ABC1D23):");
                string placa = Console.ReadLine();

                // Normaliza a string e remove hífens e converte para maiúsculas
                // Validação com Regex
                string placaNormalizada = placa.Replace("-", "").Trim().ToUpper();

                // Define as expressões regulares para os dois formatos de placa
                Regex regexPlacaAntiga = new Regex("^[A-Z]{3}[0-9]{4}$");
                Regex regexPlacaMercosul = new Regex("^[A-Z]{3}[0-9][A-Z][0-9]{2}$");

                // Verifica se a placa corresponde a um dos formatos válidos
                if (regexPlacaAntiga.IsMatch(placaNormalizada) || regexPlacaMercosul.IsMatch(placaNormalizada))
                {
                    // Adiciona a placa normalizada à lista
                    veiculos.Add(placaNormalizada);
                    Console.WriteLine($"O veículo com a placa {placaNormalizada} foi estacionado com sucesso!");

                    // Sai do laço de repetição, pois a placa é válida
                    break;
                }
                else
                {
                    // Informa o usuário que a placa é inválida e o laço continua
                    Console.WriteLine("Placa inválida! Por favor, digite uma placa no formato padrão (ABC1234) ou Mercosul (ABC1D23).");
                }
            
            }



            // codigo basico
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            //     Console.WriteLine("Digite a placa do veículo para estacionar:");

            // // --- Codigo implementado 
            // string placa = Console.ReadLine();
            // veiculos.Add(placa);

            // Console.WriteLine($"Veículo {placa} estacionado com sucesso!");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = Console.ReadLine();

            // Normaliza a placa digitada para a busca, assim como foi feito no cadastro
            string placaNormalizada = placa.Replace("-", "").Trim().ToUpper();

            // Verifica das placas corretas
            if (veiculos.Any(x => x == placaNormalizada))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                // foi implementado o convert ... para converter o texto em numeros, e o readline para receber a infomação
                int horas = Convert.ToInt32(Console.ReadLine());
                // foi adicionado o calco precoInicial + precoPorHora * horas
                decimal valorTotal = precoInicial + precoPorHora * horas;

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*
                veiculos.Remove(placaNormalizada);

                Console.WriteLine($"O veículo {placaNormalizada} foi removido e o preço total foi de: R$ {valorTotal:F2}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
