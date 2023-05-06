

public record ValueModel
{
    public Guid OfferId { get; set; }
    public DateTime CurrentDate { get; set; }
    //public DateTime EndDate { get; set; }
    public bool Active { get; set; }
    public string Desc { get; set; }
}