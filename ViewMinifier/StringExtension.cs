namespace HtmlMinifier {

    public static class StringExtension {

        /// <summary>
        /// Checks if a file extension matches 
        /// any given types for an ASP.net application
        /// </summary>
        /// <param name="value">The html file name.</param>
        /// <returns>A boolean if the file is an html file.</returns>
        public static bool IsHtmlFile(this string value) {
            var file = value.ToLower();

            return file.EndsWith(".cshtml", System.StringComparison.OrdinalIgnoreCase) ||
                    file.EndsWith(".vbhtml", System.StringComparison.OrdinalIgnoreCase) ||
                    file.EndsWith(".aspx", System.StringComparison.OrdinalIgnoreCase) ||
                    file.EndsWith(".html", System.StringComparison.OrdinalIgnoreCase) ||
                    file.EndsWith(".htm", System.StringComparison.OrdinalIgnoreCase) ||
                    file.EndsWith(".ascx", System.StringComparison.OrdinalIgnoreCase) ||
                    file.EndsWith(".master", System.StringComparison.OrdinalIgnoreCase) ||
                    file.EndsWith(".inc", System.StringComparison.OrdinalIgnoreCase);
        }

    }

}
