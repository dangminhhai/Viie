namespace BaseLibrary.DTOs
{
    public class LocaleStringResourceDto
    {
        public int Id { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
        public int LanguageId { get; set; }
    }
}
