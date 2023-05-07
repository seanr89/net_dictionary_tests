using Bogus;

public static class BogusCreator{
    
    public static ValueModel CreateModel()
    {
        var faker = new Faker<ValueModel>()
        .RuleFor(v => v.OfferId, f => Guid.NewGuid())
        .RuleFor(v => v.CurrentDate, f => f.Date.Recent(50))
        .RuleFor(v => v.EndDate, f => f.Date.Future(50))
        .RuleFor(v => v.Desc, f => f.Lorem.Sentences(1))
        .RuleFor(v => v.Active, true);

        return faker.Generate();
    }

    public static List<ValueModel> CreateModelList(int count = 1000)
    {
        var faker = new Faker<ValueModel>()
        .RuleFor(v => v.OfferId, f => Guid.NewGuid())
        .RuleFor(v => v.CurrentDate, f => f.Date.Recent(50))
        .RuleFor(v => v.EndDate, f => f.Date.Future())
        .RuleFor(v => v.Desc, f => f.Lorem.Sentences(1))
        .RuleFor(v => v.Active, true);

        return faker.Generate(count);
    }
}