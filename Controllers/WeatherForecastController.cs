using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly INumGenerator _numGenerator;
    private readonly INumGenerator2 _numGenerator2;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, INumGenerator numGenerator, INumGenerator2 numGenerator2)
    {
        _logger = logger;
        _numGenerator = numGenerator;
        _numGenerator2 = numGenerator2;
    }

    [HttpGet]
    public string Get()
    {
        int random2 = _numGenerator.RandomNumb;
        int random1 = _numGenerator2.NumGeneratorRandomNum();

        return $"Random 1: {random1.ToString()} , Random 2:{random2.ToString()}";
    }
}

// Aciklama 

/*
Dependendeny Injection Nedir, Neden Kullanırız

Dependency Injection, yaptığımız geliştirmelerde loosely coupled code sağlamak için kullanılan ve içerisinde Inversion of Control ve Dependency Inversion 
prensiplerini barındıran bir design pattern’dir.

Amaç kod içerisindeki bağımlılıkları azaltarak yada ters bağımlık oluşturak da diyebiliriz, gelişime açık esnek yapılar sunmak ile birlikte test
edilebilir kod yazmaktır. Başka bir deyiş ile direkt Concrate Classlar ile çalışmak yerine Interface’lerle çalışabilceğimiz, bu interface’lerinden 
arkasında çalışacak concrate class’ı belirleyebileceğimiz ve bu Concrate Class’ın Instance’ının life time ile ilgili tüm süreci yönettiğimiz bir yapıdır 
diyebiliriz.

Kısaca Dependency Injection kullanımın yararlarından bahsedecek olur isek;

.Modüller veya companentler arasındaki bağlılığı azaltır
.Uygulamanın bakım ve geliştirme aşamasında kolaylık sağlar
.Kodun test edilebilmesini kolaylaştırır,
.Kodun okunabilirliğini artırır.

Neyseki tüm bunlarla biz uğraşmıyoruz. Tüm bu işleri yöneteceğimiz tool’lar mevcut ve bizde bunlardan biri olan ve .Net core projelerinde built-in olarak
gelen Microsoft Dependency Injection’dan bahsedeceğiz.

*/



// AddSingelton

// Bir sinifi Singelton olarak DI'a kayit ettigimiz zaman uygulama ayagi kalktigi andan itibaren 1 kere generate eder ve uygulama kapanana kadar aynı instance uzerinden
// islem yapilmaya devam edilir. Uygulama basladi bir tane instance olusturuldu diyelim ve bu instance i 10 binlerce istek de kullaniyoruz hayal edin bu durumda dar bogaz
// yasama olasiligimiz artiyor. Uygulama kapanirken instance'in referance inin tuttugu degere null atanir ve bu sekilde ram tarafindan tekrar kullanima acilir.

//--------------------------------------------------------------------------------------------------------------------------------------

// AddScoped

// Bir sinifi Scoped olarak DI'a kayit ettigimiz zaman uygulamanin ilgili kismi her istek de yeni bir instance olusturur ve request sonlanana kadar instance'in
// memory de kapladigi kaynak miktari tekrar kullanima acilmaz. Request sonlanir sonlanmaz instance'a null atanir ve memoryde kapladigi kaynaklar kullanıma acilir.

//--------------------------------------------------------------------------------------------------------------------------------------

// AddTransient

// Bir sinifi Transient olarak DI'a kayit ettigmiz zaman ilgili sinif' her çagirildiginda tekrar o instance uretilir. Bir istek aldik diyelim aynı istek zaman
// diliminde o sinifa 1 den fazla kez ulasmamiz gerekti o halde tekrar tekrar gider yeni instance'lar uretir.
// Ilgili nesnenin yasam suresi ilgili nesnenin tekrar cagirilmasi ile sinirlidir. Bu da yuksek ram kaynaklarinin gereksiz fazla tuketilebilmesine 
// sebeb olabilir dikkatli kullanilmalidir.
