using System;

namespace MyApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            // // Se instanciar um datetime sem passar nada, vai atribuir um valor padrão
            // var data = new DateTime(2022, 04, 18, 15, 37, 00);
            // // Para pegar o valor de agora
            // //var data = DateTime.Now;
            // Console.WriteLine(data);
            // Console.WriteLine(data.Year);
            // Console.WriteLine(data.Month);
            // Console.WriteLine(data.Day);
            // Console.WriteLine(data.Hour);
            // Console.WriteLine(data.Minute);
            // Console.WriteLine(data.Second);

            // Console.WriteLine((int)data.DayOfWeek);
            // Console.WriteLine(data.DayOfYear);

            // ==================

            // var data = DateTime.Now;
            // // y = mês com ano, yy = dois primeiros digitos do ano, yyy = ano completo assim como yyyy
            // // M ou MM = mês, m = minutos 
            // // d = dias
            // // h = horas, s = segundos
            // // var formatada = String.Format("{0:dd/MM/yyyy hh:mm:ss:ff z}", data);
            // // Console.WriteLine(formatada);

            // var formatada = String.Format("{0:r}", data);
            // //var formatada = String.Format("{0:s}", data);

            // Console.WriteLine(formatada);

            // ===============

            // var data = DateTime.Now;
            // Console.WriteLine(data);

            // Console.WriteLine(data.AddYears(2));

            // Console.WriteLine(data.AddMonths(9));

            // Console.WriteLine(data.AddDays(27));

            // ===================

            var data = DateTime.Now;
            // É impossivel comparar o data com um DateTime.Now, pois vai haver uma diferença de milisegundos
            // pro data criado acima, com o instanciado no iff
            // Já no caso de pegar só a data é possivel, pois não se trabalha com horas
            // Pode fazer qualquer comparação
            if (data.Date == DateTime.Now.Date)
            {
                Console.WriteLine("É igual");
            }
        }
    }
}
