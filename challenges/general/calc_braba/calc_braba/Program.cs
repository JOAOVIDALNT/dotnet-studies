
var result = calc(1, 1, false);
var superResult = calc(3, 3, true);

Console.WriteLine($"Without superpower: {result} \nnow, with superpower: {superResult}");

object calc(int n1, int n2, bool superPower)
{
    var sum = n1 + n2;
    var mult = n1 * n2;

    if (superPower)
        return new Tuple<int, int>(sum, mult);
    else
        return sum;
}