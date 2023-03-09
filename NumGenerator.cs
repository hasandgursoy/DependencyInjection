namespace DependencyInjection;

public class NumGenerator : INumGenerator
{
    public int RandomNumb { get; }

    public NumGenerator()
    {
        RandomNumb = new Random().Next(1000);
    }

}

public interface INumGenerator
{

    public int RandomNumb { get; }

}



