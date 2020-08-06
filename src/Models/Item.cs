using System;

namespace VocabularyBuilderApi.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public string Meaning { get; set; }
        public string Example { get; set; }
        public string DictionaryUrl { get; set; }
        public string ThesaurusUrl { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}