using System.Collections;
using System.Collections.Generic;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;
using UnityEngine.Localization.SmartFormat;

namespace Ichi.Common
{
    public class LocalizationText : ILocalizationText
    {
        private string table;

        public LocalizationText(string table) {
            this.table = table;
        }

        public string Localize(string key, params object[] values) {
            return new LocalizedStringTable(this.table)
                .GetTable()
                .GetEntry(key)
                .GetLocalizedString(values);
        }
    }
}
