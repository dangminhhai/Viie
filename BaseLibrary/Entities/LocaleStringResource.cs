namespace BaseLibrary.Entities
{
    public class LocaleStringResource
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string? ResourceKey { get; set; }
        public string? ResourceValue { get; set; }
    }

}
