﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HtmlMinifier {
    /// <summary>
    /// The html minification class.
    /// </summary>
    public class Program {

        static void Main(string[] args) {
            if (args.Length == 0) {
                Console.WriteLine("Please provide folder path or file(s) to process");
            } else {
                // Determine which features to enable or disable
                var features = new Features(args);
                foreach (var arg in args) {
                    if (Directory.Exists(arg)) {
                        ProcessDirectory(features, arg);
                    } else if (File.Exists(arg)) {
                        ProcessFile(features, arg);
                    }
                }
                Console.WriteLine("Minification Complete");
            }
        }

        /// <summary>
        /// Minify all files in a given directory
        /// </summary>
        /// <param name="features">Features object</param>
        /// <param name="folderPath">The path to the folder</param>
        public static void ProcessDirectory(Features features, string folderPath) {
            // Loop through the files in the folder and look for any of the following extensions
            foreach (string folder in GetDirectories(folderPath)) {
                foreach (var filePath in Directory.GetFiles(folder)) {
                    if (filePath.IsHtmlFile())
                        ProcessFile(features, filePath);
                }
            }
        }

        /// <summary>
        /// Minify a given file
        /// </summary>
        /// <param name="features">Features object</param>
        /// <param name="filePath">The path to the file</param>
        public static void ProcessFile(Features features, string filePath) {
            Console.WriteLine("Beginning Minification");

            // Minify contents
            string minifiedContents = MinifyHtml(filePath, features);

            // Write to the same file
            File.WriteAllText(filePath, minifiedContents, Encoding.UTF8);
            Console.WriteLine("Minified file : " + filePath);
        }

        /// <summary>
        /// Gets the directories and subdirectories for a given path.
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>A list of the directories.</returns>
        public static IEnumerable<string> GetDirectories(string path) {
            return new[] { path }.Concat(Directory.GetDirectories(path, "*", SearchOption.AllDirectories));
        }

        /// <summary>
        /// Minifies the contents of the given view.
        /// </summary>
        /// <param name="filePath"> The file path. </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string MinifyHtml(string filePath, Features features) {
            using (var reader = new StreamReader(filePath)) {
                return reader.MinifyHtmlCode(features);
            }
        }

    }
}
