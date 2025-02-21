namespace ResFin.Domain.Residences;

public record Currency
    {
    #region Accepted Currencies

    internal static readonly Currency None = new Currency(CurrencyTypes.None.ToString());
    public static readonly Currency USD = new Currency(CurrencyTypes.USD.ToString());
    public static readonly Currency Euro = new Currency(CurrencyTypes.Euro.ToString());
    public static readonly Currency IranRial = new Currency(CurrencyTypes.IranRial.ToString());
    public static readonly Currency CanadaDollar = new Currency(CurrencyTypes.CanadaDollar.ToString());
    public static readonly Currency AustraliaDollar = new Currency(CurrencyTypes.AustraliaDollar.ToString());
    public static readonly Currency JapanYen = new Currency(CurrencyTypes.JapanYen.ToString());
    public static readonly Currency ChinaYuan = new Currency(CurrencyTypes.ChinaYuan.ToString());
    public static readonly Currency TurkeyLir = new Currency(CurrencyTypes.TurkeyLir.ToString());
    public static readonly Currency EnglandPound = new Currency(CurrencyTypes.EnglandPound.ToString());
    public static readonly Currency BitCoin = new Currency(CurrencyTypes.BitCoin.ToString());
    public static readonly Currency USDT = new Currency(CurrencyTypes.USDT.ToString());

    #endregion


    #region Cunstructor

    private Currency ( string code ) => Type = code;

    #endregion

    public string Type { get; init; }


    public static Currency FromCode ( string currencyType )
        {
        return All.FirstOrDefault(c => c.Type == currencyType) ??
               throw new ApplicationException("The Currency Type is not Supported");
        }

    public static readonly IReadOnlyCollection<Currency> All =
    [
        USD,
      Euro,
      IranRial,
      CanadaDollar,
      AustraliaDollar,
      JapanYen,
      ChinaYuan,
      TurkeyLir,
      EnglandPound,
      BitCoin,
      USDT
    ];
    }