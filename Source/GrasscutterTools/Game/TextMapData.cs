/**
 *  Grasscutter Tools
 *  Copyright (C) 2022 jie65535
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU Affero General Public License as published
 *  by the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU Affero General Public License for more details.
 *
 *  You should have received a copy of the GNU Affero General Public License
 *  along with this program.  If not, see <https://www.gnu.org/licenses/>.
 *
 **/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

namespace GrasscutterTools.Game
{
    internal class TextMapData
    {
        // 语言代码到TextMap文件标识符的映射
        // 匹配规则：文件名必须包含标识符，如 TextMapCHS.json, TextMap_MediumCHS.json, TextMapRU_0.json 等
        private static readonly Dictionary<string, string[]> LanguageIdentifiers = new Dictionary<string, string[]>
        {
            ["zh-cn"] = new[] { "CHS" },
            ["zh-tw"] = new[] { "CHT" },
            ["en-us"] = new[] { "EN" },
            ["ru-ru"] = new[] { "RU" },
        };

        private string _textMapDirPath;

        public TextMapData(string resourcesDirPath)
        {
            LoadManualTextMap(Path.Combine(resourcesDirPath, "ExcelBinOutput", "ManualTextMapConfigData.json"));
            _textMapDirPath = Path.Combine(resourcesDirPath, "TextMap");
            LoadTextMaps(_textMapDirPath);
            LoadTextMapByLanguage("zh-cn");
            DefaultTextMap = TextMap;
        }

        public Dictionary<string, string> ManualTextMap;
        public Dictionary<string, string> DefaultTextMap;
        public Dictionary<string, string> TextMap;
        public string[] TextMapFilePaths;
        public string[] TextMapFiles;

        private void LoadManualTextMap(string manualTextMapPath)
        {
            if (!File.Exists(manualTextMapPath)) return;

            using (var fs = File.OpenRead(manualTextMapPath))
            using (var sr = new StreamReader(fs))
            using (var reader = new JsonTextReader(sr))
            {
                ManualTextMap = new Dictionary<string, string>();
                string textMapId = null, textMapContextHash = null;
                while (reader.Read())
                {


                    if (reader.TokenType == JsonToken.PropertyName && ((string)reader.Value == "textMapId" || (string)reader.Value == "TextMapId"))
                    {
                        textMapId = reader.ReadAsString();
                    }

                    if (reader.TokenType == JsonToken.PropertyName && ((string)reader.Value == "textMapContentTextMapHash" || (string)reader.Value == "TextMapContentTextMapHash"))
                    {
                        textMapContextHash = reader.ReadAsString();
                    }

                    if (textMapId != null && textMapContextHash != null)
                    {
                        ManualTextMap.Add(textMapContextHash, textMapId);
                        textMapId = null;
                        textMapContextHash = null;
                    }
                }
            }
        }

        private void LoadTextMaps(string textMapDirPath)
        {
            TextMapFilePaths = Directory.GetFiles(textMapDirPath, "TextMap*.json");
            if (TextMapFilePaths.Length == 0)
                throw new FileNotFoundException("TextMap*.json Not Found");
            TextMapFiles = TextMapFilePaths.Select(n => Path.GetFileNameWithoutExtension(n)).ToArray();
        }

        /// <summary>
        /// 根据语言代码加载TextMap，自动匹配并合并所有相关文件
        /// 匹配规则：文件名以"TextMap"开头，并包含对应的语言标识符
        /// 例如：TextMapCHS.json, TextMap_MediumCHS.json, TextMapRU_0.json, TextMapRU_1.json
        /// </summary>
        /// <param name="languageCode">语言代码，如 "zh-cn", "en-us", "ru-ru"</param>
        public void LoadTextMapByLanguage(string languageCode)
        {
            TextMap = new Dictionary<string, string>();

            if (!LanguageIdentifiers.ContainsKey(languageCode))
            {
                Console.WriteLine($"Warning: Language code '{languageCode}' not found in LanguageIdentifiers, falling back to zh-cn");
                languageCode = "zh-cn";
            }

            var identifiers = LanguageIdentifiers[languageCode];
            var loadedFiles = new List<string>();

            foreach (var identifier in identifiers)
            {
                // 查找所有包含该标识符的文件
                // 例如：TextMap*CHS*.json 会匹配 TextMapCHS.json, TextMap_MediumCHS.json 等
                var matchingFiles = TextMapFilePaths
                    .Where(f =>
                    {
                        var fileNameWithoutExt = Path.GetFileNameWithoutExtension(f);
                        return fileNameWithoutExt.StartsWith("TextMap") &&
                               fileNameWithoutExt.Contains(identifier);
                    })
                    .OrderBy(f => f)  // 按文件名排序
                    .ToArray();

                foreach (var file in matchingFiles)
                {
                    if (loadedFiles.Contains(file))
                        continue;

                    LoadTextMapFile(file, TextMap);
                    loadedFiles.Add(file);
                }
            }

            if (loadedFiles.Count == 0)
            {
                Console.WriteLine($"Warning: No TextMap files found for language '{languageCode}' with identifiers: {string.Join(", ", identifiers)}");
            }
            else
            {
                Console.WriteLine($"Loaded {loadedFiles.Count} TextMap file(s) for language '{languageCode}': {string.Join(", ", loadedFiles.Select(Path.GetFileName))}");
            }
        }

        /// <summary>
        /// 从单个文件加载TextMap并合并到目标字典
        /// </summary>
        private void LoadTextMapFile(string filePath, Dictionary<string, string> targetDict)
        {
            try
            {
                using (var fs = File.OpenRead(filePath))
                using (var sr = new StreamReader(fs))
                using (var reader = new JsonTextReader(sr))
                {
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonToken.PropertyName)
                        {
                            var key = (string)reader.Value;
                            var value = reader.ReadAsString();

                            // 如果key已存在，新值覆盖旧值（后加载的文件优先）
                            targetDict[key] = value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading TextMap file '{filePath}': {ex.Message}");
            }
        }


        public string GetText(string textMapHash)
        {
            return TextMap.TryGetValue(textMapHash, out var text) ? text
                : DefaultTextMap.TryGetValue(textMapHash, out text) ? "[CHS] - " + text
                : "[N/A] " + textMapHash;
        }

        public bool TryGetText(string textMapHash, out string text)
        {
            if (TextMap.TryGetValue(textMapHash, out text))
            {
                return true;
            }

            if (DefaultTextMap.TryGetValue(textMapHash, out text))
            {
                text = "[CHS] - " + text;
                return true;
            }

            text = "[N/A] " + textMapHash;
            return false;
        }
    }
}