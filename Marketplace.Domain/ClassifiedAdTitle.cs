using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
    public record ClassifiedAdTitle
    {
        private string _title;
        private ClassifiedAdTitle(string title)
        {
            if (title.Length > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(title), "Title cannot be longer than 100 characters");
            }

            _title = title;
        }

        public static ClassifiedAdTitle FromString(string title) => new (title);

        public static ClassifiedAdTitle FromHtml(string htmlTitle)
        {
            var supportedTagReplaced = htmlTitle
                .Replace("<i>", "*")
                .Replace("</i>", "*")
                .Replace("</b>", "**")
                .Replace("</b>", "**");
            return new ClassifiedAdTitle(Regex.Replace(supportedTagReplaced,"<.*?>", string.Empty));
        }
    }


}
