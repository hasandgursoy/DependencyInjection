using DependencyInjection;

public class NumGenerator2 : INumGenerator2
{
    private readonly INumGenerator _numGenerator;
    public int RandomNumb { get; }

    public NumGenerator2(INumGenerator numGenerator)
    {
        RandomNumb = new Random().Next(1000);
        _numGenerator = numGenerator;
    }

    public int NumGeneratorRandomNum()
    {
        return _numGenerator.RandomNumb;
    }
}

public interface INumGenerator2
{

    public int RandomNumb { get; }

    public int NumGeneratorRandomNum();

}