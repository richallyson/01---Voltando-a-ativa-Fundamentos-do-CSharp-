using System;
using System.Globalization;

namespace WorkingWithDates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            // === Timezone ===

            // var pt = new CultureInfo("pt-PT");
            // var br = new CultureInfo("pt-BR");
            // var en = new CultureInfo("en-US");
            // var de = new CultureInfo("de-DE");

            // // Pega a cultura atual da máquina
            // // Só usar o system globalization junto do código, se ele n for startado no using
            // // Lembrando que a cultura que vai ser pega é a máquina
            // // Vamos supor que o servidor está localizado na china, ele vai pegar a cultura da china
            // // Mesmo você estando no brasil
            // var atual = System.Globalization.CultureInfo.CurrentCulture;

            // // Para isso, para se trabalhar com globalização, se recomenda pegar o date como abaixo
            // // Sendo assim ele vai pegar a hora base, e não vai adicionar nenhum timezone
            // var utcDate = DateTime.UtcNow;

            // // Passando a cultura dps do argumento de como se quer apresentar o date, ele retorna a data na cultura selecionada
            // Console.WriteLine(DateTime.Now.ToString("D", de));
            // Console.WriteLine(DateTime.Now.ToString(atual));

            // // Como visto, ele n vai adicionar timezone. Como estou no Brasil ele não vai subtrair o -3GMT
            // // Vai apresentar a hora pura
            // // Sem o utcnow ele pega a hora do servidor, com ele pega a hora sem adições ou subtrações de gmt
            // // Sempre que for trampar com aplicação globalizada, trabalhar com o UTCNOW
            // Console.WriteLine(utcDate);

            // // E assim fica a hora adicionando o timezone do local de onde eu me encontro
            // Console.WriteLine(utcDate.ToLocalTime());

            // // Caso eu não queira usar o timzone da máquina eu posso pegar o timezone de outros cantos usando:            
            // var timezoneAustralia = TimeZoneInfo.FindSystemTimeZoneById("New Zealand Standard Time");
            // Console.WriteLine(timezoneAustralia);

            // // Agora vamos converter a hora UTC para a hora usanado o timezone da australia
            // var horaAustralia = TimeZoneInfo.ConvertTimeFromUtc(utcDate, timezoneAustralia);

            // // Essa é a maneira mais usual de se trabalhar com hora quando se tem um sistema globalizado
            // // Você pega a hora pura usando utcNow, e depois transforma ela para a hora do cliente, usando o timezone de onde ele se localiza
            // Console.WriteLine(horaAustralia);


            // var timezones = TimeZoneInfo.GetSystemTimeZones();
            // foreach (var timezone in timezones)
            // {
            //     Console.WriteLine(timezone.Id);
            //     Console.WriteLine(timezone);
            //     Console.WriteLine(TimeZoneInfo.ConvertTimeFromUtc(utcDate, timezone));
            //     Console.WriteLine("----------");
            // }

            // === Timespan ===

            // // Timespan é uma unidade de medida para data e hora universal
            // var timeSpan = new TimeSpan();

            // // Ele retorna pra gente a fração do segundo, de tempo
            // // Muito bom para trabalhar com diferença de horas
            // // Saber quanto tempo passou de uma relacionada operação, etc
            // Console.WriteLine(timeSpan);

            // // Caso atribua apenas uma coisa dentro do time span, ele trata como nanosegundo
            // var timeSpanNanoSegundos = new TimeSpan(1);

            // // Aqui podemos ver que ele adicionou uma fração nova, em nano segundos
            // Console.WriteLine(timeSpanNanoSegundos);

            // // Já, caso passe três argumentos, como visto abaixo, ele atribui a hora, minuto e segundo
            // // Ou seja, ele cria uma hora
            // var timeSpanHoraMinutoSegundo = new TimeSpan(5, 12, 8);
            // Console.WriteLine(timeSpanHoraMinutoSegundo);

            // // Se adicionar mais um argumento a esquerda, ele adiciona o dia
            // var timeSpanDiaHoraMinutoSegundo = new TimeSpan(3, 5, 50, 10);
            // Console.WriteLine(timeSpanDiaHoraMinutoSegundo);

            // // Se adicionar mais um argumento ao final, ele atribui a milisegundo
            // var timeSpanDiaHoraMinutoSegundoMilisegundo = new TimeSpan(4, 14, 7, 2, 122);
            // Console.WriteLine(timeSpanDiaHoraMinutoSegundoMilisegundo);

            // // Eles são usados para aplicar aritimetica sobre datas, como visto abaixo
            // Console.WriteLine(timeSpanHoraMinutoSegundo - timeSpanDiaHoraMinutoSegundo);

            // // Retorna apenas os dias. E tem função pra cada tipo de tempo: minutos, segundos, mili...
            // Console.WriteLine(timeSpanDiaHoraMinutoSegundo.Days);

            // // E aqui eu to adicionando mais 12 hrs para o timespan abaixo
            // Console.WriteLine(timeSpanDiaHoraMinutoSegundo.Add(new TimeSpan(12, 0, 0)));

            // === Funções extras ===

            // Para se ver quantos dias tem em um mês. Passar o ano e o mês como parametro
            // Lembrando que aqui é um enumerador e n uma lista, então sempre começamos do 1
            Console.WriteLine(DateTime.DaysInMonth(2022, 4));

            // Agora vamo criar uma função chamada IsWeekend para analisar se é fim de semana ou não
            // Como sabemos uma função não pode ser criada no escopo de outra função, então ta lá fora
            // Com a função criada, agora vamos analisar se é fim de semana ou não
            // Lembrando que ele precisa receber um tipo DayOfWeek
            // Dentro do console, é como se vê que dia da semana é hj
            Console.WriteLine(IsWeekend(DateTime.Now.DayOfWeek));

            // Agora vamos ver se estamos ou não em horario de verão
            // Retorna um booleano
            Console.WriteLine(DateTime.Now.IsDaylightSavingTime());

        }

        // Aqui oh
        // Essa função analisa se é sábado ou domingo e retorna um booleano

        static bool IsWeekend(DayOfWeek today)
        {
            return today == DayOfWeek.Saturday || today == DayOfWeek.Sunday;
        }
    }
}
