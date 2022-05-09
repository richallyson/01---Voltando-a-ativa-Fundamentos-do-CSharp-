namespace EstudoLista3.ContentContext
{
    public class Article : Content
    {
        public Article(string title, string url, long contentText) : base(title, url)
        {
            ContentText = contentText;
        }

        public long ContentText { get; set; }
    }
}