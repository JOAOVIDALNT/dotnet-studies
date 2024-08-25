
List<Tuple<decimal, DateTime>> dayliInvoicingList = new List<Tuple<decimal, DateTime>>();

Random rand = new Random();

for(int i = 0; i <= 364; i++)
{
    var firstDay = new DateTime(2023,01,01);
    var invoicing = (decimal)rand.NextDouble() * 10000;
    var dayli = new Tuple<decimal, DateTime>(invoicing, firstDay.AddDays(i));
    dayliInvoicingList.Add(dayli);
}

var daysWithInvoicing = dayliInvoicingList.Where(x => x.Item1 > 0);

var lowestDayliInvoincing = daysWithInvoicing.Min();
var biggestDayliInvoicing = daysWithInvoicing.Max();

var invoicingAvarage = daysWithInvoicing.Average(x => x.Item1);

var aboveAverageDays = daysWithInvoicing.Where(x => x.Item1 > invoicingAvarage);

Console
    .WriteLine($"Relatório de faturamento anual \nPior dia: {lowestDayliInvoincing!.Item2.ToString("dd/MM/yyyy")} - R$ {lowestDayliInvoincing.Item1.ToString("F2")} \n" +
    $"Melhor dia: {biggestDayliInvoicing!.Item2.ToString("dd/MM/yyyy")} - R$ {biggestDayliInvoicing.Item1.ToString("F2")} \n" +
    $"Total de dias em que o faturamento foi acima da média anual: {aboveAverageDays.Count()}");