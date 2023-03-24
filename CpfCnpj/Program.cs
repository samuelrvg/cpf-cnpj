using CpfCnpj.Original;
using CpfCnpj.Performatico;
using System.Diagnostics;

var sw = new Stopwatch();
var before2 = GC.CollectionCount(2);
var before1 = GC.CollectionCount(1);
var before0 = GC.CollectionCount(0);
//Func<string, bool> sut = PerformaticoCPF.ValidarCPF;

sw.Start();
for (int i = 0; i < 1_000_000; i++)
{
    //var cpfCnpj1 = CPF.StripAndPadWitZeros("771.189.500-33");
    //if (!CPF.IsValid(cpfCnpj1))
    //{
    //    throw new Exception("Error!");
    //}

    //var cpfCnpj2 = CPF.StripAndPadWitZeros("771.189.500-34");
    //if (CPF.IsValid(cpfCnpj2))
    //{
    //    throw new Exception("Error!");
    //}

    var cpfCnpj1 = CPF.StripAndPadWitZeros("95.572.798/0001-52");
    if (!CNPJ.IsValid(cpfCnpj1))
    {
        throw new Exception("Error!");
    }

    var cpfCnpj2 = CPF.StripAndPadWitZeros("92.143.079/0001-21");
    if (CNPJ.IsValid(cpfCnpj2))
    {
        throw new Exception("Error!");
    }

    //------------------------------------
    //-----------PERFORMATICO-------------
    //------------------------------------

    //if (!PerformaticoCPF.ValidarCPF("771.189.500-33"))
    //{
    //    throw new Exception("Error!");
    //}

    //if (PerformaticoCPF.ValidarCPF("771.189.500-34"))
    //{
    //    throw new Exception("Error!");
    //}

    //var cpfCnpj1 = CPF.StripAndPadWitZeros("95.572.798/0001-52");
    //if (!PerformaticoCNPJ.ValidarCNPJ(cpfCnpj1))
    //{
    //    throw new Exception("Error!");
    //}

    //var cpfCnpj2 = CPF.StripAndPadWitZeros("92.143.079/0001-21");
    //if (PerformaticoCNPJ.ValidarCNPJ(cpfCnpj2))
    //{
    //    throw new Exception("Error!");
    //}
}
sw.Stop();

Console.WriteLine($"Tempo total: {sw.ElapsedMilliseconds}ms");
Console.WriteLine($"GC Gen #2  : {GC.CollectionCount(2) - before2}");
Console.WriteLine($"GC Gen #1  : {GC.CollectionCount(1) - before1}");
Console.WriteLine($"GC Gen #0  : {GC.CollectionCount(0) - before0}");
Console.WriteLine("Done!");